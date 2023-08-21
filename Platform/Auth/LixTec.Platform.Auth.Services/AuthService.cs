using System.Text;
using Newtonsoft.Json;
using Google.Cloud.Firestore;
using System.Security.Claims;
using LixTec.Platform.Common.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using LixTec.Platform.Auth.Entity.Models;
using LixTec.Platform.Auth.Service.Mapping;
using LixTec.Platform.Auth.Service.Interfaces;
using LixTec.Platform.Auth.Services.Models.Result;
using LixTec.Platform.Auth.Services.Models.Request;
using LixTec.Platform.Auth.Factory.Repository.Interfaces;
using LixTec.Platform.Auth.Common;

namespace LixTec.Platform.Auth.Service;

public class AuthService : IAuthService
{
    private readonly AuthMapper _authMapper;
    private readonly IUserRepositoryFactory _userRepositoryFactory;
    private readonly Settings _settings;
    private readonly FirestoreDb _fireStoreDb;
    private readonly string ProjectId = "lixtec-dac2e";

    public AuthService(IUserRepositoryFactory userRepositoryFactory, Settings settings)
    {
        _authMapper = new AuthMapper();
        _userRepositoryFactory = userRepositoryFactory;
        _settings = settings;
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "./lixtec-dac2e.json");
        _fireStoreDb = FirestoreDb.Create(ProjectId);
    }

    public async Task<AuthenticateResult> AuthenticateAsync(AuthenticateRequest authenticateRequest)
    {

        Query userQuery = _fireStoreDb.Collection("User");

        QuerySnapshot userQuerySnapshot = await userQuery.GetSnapshotAsync();


        foreach (DocumentSnapshot documentSnapshot in userQuerySnapshot.Documents)
        {
            if (documentSnapshot.Exists)
            {
                Dictionary<string, object> user = documentSnapshot.ToDictionary();

                string result = JsonConvert.SerializeObject(user);

                User users = JsonConvert.DeserializeObject<User>(result);

                if (users != null)
                {
                    if (authenticateRequest.Login == users.Email && authenticateRequest.Password == users.Password)
                    {
                        string jwtToken = GenerateJwtToken(authenticateRequest, users.UserId.ToString());
                        AuthenticateResult authenticateResult = _authMapper.Map(jwtToken, users, documentSnapshot.Id);
                        return authenticateResult;
                    }
                    else
                        throw new AuthException("Dados inválidos");
                }
                else
                    throw new AuthException("Usuário não encontrado");

            }
        }
        throw new AuthException("Ocorreu um erro inesperado");
    }

    private string GenerateJwtToken(AuthenticateRequest authenticateRequest, string userId)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        byte[] key = Encoding.ASCII.GetBytes(_settings.JwtSecret);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, authenticateRequest.Login),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, "default")
            }),
            Expires = DateTime.UtcNow.AddMinutes(_settings.JwtExpirationTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

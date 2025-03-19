using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using RentalSystem.Class;
using RentalSystem.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pos.Services
{
    public class UserServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;

        public UserServices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }
        public async Task<List<Users>> UserLogin(string username, string password)
        {
            List<Users> user = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("Userlogin", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("_UserName", username);
                com.Parameters.AddWithValue("_Password", password);

                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    user.Add(new Users
                    {
                        Id = rdr["Id"].ToString(),
                        Fname = rdr["Fname"].ToString(),
                        Mname = rdr["Mname"].ToString(),
                        Lname = rdr["Lname"].ToString(),
                        Ext = rdr["Ext"].ToString(),
                        Address = rdr["Address"].ToString(),
                        Contact = rdr["Contact"].ToString(),
                        Role = rdr["Role"].ToString(),
                        UserName = rdr["UserName"].ToString(),
                        Email = rdr["Email"].ToString(),
                    });
                }
                if (user.Count > 0)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new
                        SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)

                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    user[0].Token = tokenHandler.WriteToken(token);
                }
                return user;
            }
        }
    }
}
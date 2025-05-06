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
                    new Claim (ClaimTypes.Role.ToString(),user[0].Role),
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

        public async Task<List<Users>> SearchUsers(string search)
        {
            List<Users> users = new List<Users>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchUsers", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("searchWildcard", $"{search}%");
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        users.Add(new Users
                        {
                            Id = rdr["Id"].ToString(),
                            Fname = rdr["Fname"].ToString(),
                            Fullname = rdr["Fullname"].ToString(),
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
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return users;
        }

        public async Task<int> Register(Users user)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("Register", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    // Ensure Id is not null or empty
                    if (string.IsNullOrEmpty(user.Id))
                    {
                        user.Id = Guid.NewGuid().ToString();
                    }

                    com.Parameters.AddWithValue("_Id", user.Id);
                    com.Parameters.AddWithValue("_Fname", user.Fname);
                    com.Parameters.AddWithValue("_Fname", user.Fname);
                    com.Parameters.AddWithValue("_Mname", user.Mname);
                    com.Parameters.AddWithValue("_Lname", user.Lname);
                    com.Parameters.AddWithValue("_Ext", user.Ext);
                    com.Parameters.AddWithValue("_Address", user.Address);
                    com.Parameters.AddWithValue("_Contact", user.Contact);
                    com.Parameters.AddWithValue("_Role", user.Role);
                    com.Parameters.AddWithValue("_UserName", user.UserName);
                    com.Parameters.AddWithValue("_Password", user.Password);
                    com.Parameters.AddWithValue("_Email", user.Email);

                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Register() Exception: {ex}"); // More detailed logging
                    return 0; // Ensure a return value even in case of failure
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
        }
            public async Task<List<Users>> Users()
        {
            List<Users> user = new List<Users>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewUsers", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        user.Add(new Users
                        {
                            Id = rdr["Id"].ToString(),
                            Fullname = rdr["Fullname"].ToString(),
                            Fname = rdr["Fname"].ToString(),
                            Mname = rdr["Mname"].ToString(),
                            Lname = rdr["Lname"].ToString(),
                            Ext = rdr["Ext"].ToString(),
                            Address = rdr["Address"].ToString(),
                            Contact = rdr["Contact"].ToString(),
                            Role = rdr["Role"].ToString(),
                            UserName = rdr["UserName"].ToString(),
                            Email = rdr["Email"].ToString()
                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    await con.CloseAsync().ConfigureAwait(false);
                }
            }
            return user;
        }
    }
    
}
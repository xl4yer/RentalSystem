using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using RentalSystem.Class;
using RentalSystem.Models;
using System.Data;

namespace RentalSystem.Services
{
    public class GownServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;

        public GownServices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        public async Task<List<Gowns>> Gowns()
        {
            List<Gowns> gown = new List<Gowns>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewGowns", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        gown.Add(new Gowns
                        {
                            Id = rdr["Id"].ToString(),
                            Type = rdr["Type"].ToString(),
                            Photo = rdr["Photo"] as byte[],
                            Name = rdr["Name"].ToString(),
                            Color = rdr["Color"].ToString(),
                            Size = rdr["Size"].ToString(),
                            Fee = Convert.ToDouble(rdr["Fee"]),
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
            return gown;
        }

        public async Task<int> AddGown(Gowns gown)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddGown", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Id", gown.Id);
                    com.Parameters.AddWithValue("_Type", gown.Type);
                    com.Parameters.AddWithValue("_Photo", gown.Photo);
                    com.Parameters.AddWithValue("_Name", gown.Name);
                    com.Parameters.AddWithValue("_Color", gown.Color);
                    com.Parameters.AddWithValue("_Size", gown.Size);
                    com.Parameters.AddWithValue("_Fee", gown.Fee);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
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
            return 0;
        }

        public async Task<int> UpdateGown(Gowns gown)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("UpdateGown", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Id", gown.Id);
                    com.Parameters.AddWithValue("_Type", gown.Type);
                    com.Parameters.AddWithValue("_Photo", gown.Photo);
                    com.Parameters.AddWithValue("_Name", gown.Name);
                    com.Parameters.AddWithValue("_Color", gown.Color);
                    com.Parameters.AddWithValue("_Size", gown.Size);
                    com.Parameters.AddWithValue("_Fee", gown.Fee);
                    return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
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
            return 0;
        }
    }
}

using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using RentalSystem.Class;
using RentalSystem.Models;
using System.Data;

namespace RentalSystem.Services
{
    public class RentalServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;

        public RentalServices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        public async Task<List<Rentals>> Rentals()
        {
            List<Rentals> rentals = new List<Rentals>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewRentals", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        rentals.Add(new Rentals
                        {
                            Id = rdr["Id"].ToString(),
                            GownId = rdr["GownId"].ToString(),
                            UserId = rdr["UserId"].ToString(),
                            Fullname = rdr["Fullname"].ToString(),
                            Date = Convert.ToDateTime(rdr["Date"]),
                            DueDate = Convert.ToDateTime(rdr["DueDate"]),
                            Type = rdr["Type"].ToString(),
                            Photo = rdr["Photo"] as byte[],
                            Name = rdr["Name"].ToString(),
                            Color = rdr["Color"].ToString(),
                            Size = rdr["Size"].ToString(),
                            RentalFee = Convert.ToDouble(rdr["RentalFee"]),
                            Status = rdr["Status"].ToString(),
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
            return rentals;
        }

        public async Task<List<Rentals>> UserRentals(string UserId)
        {
            List<Rentals> rentals = new List<Rentals>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("UserRentals", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_UserId", UserId);
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        rentals.Add(new Rentals
                        {
                            Id = rdr["Id"].ToString(),
                            Fullname = rdr["Fullname"].ToString(),
                            Date = Convert.ToDateTime(rdr["Date"]),
                            DueDate = Convert.ToDateTime(rdr["DueDate"]),
                            Type = rdr["Type"].ToString(),
                            Photo = rdr["Photo"] as byte[],
                            Name = rdr["Name"].ToString(),
                            Color = rdr["Color"].ToString(),
                            Size = rdr["Size"].ToString(),
                            RentalFee = Convert.ToDouble(rdr["RentalFee"]),
                            Status = rdr["Status"].ToString(),
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
            return rentals;
        }

        public async Task<int> AddRental(Rentals rentals)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddRental", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Id", rentals.Id);
                    com.Parameters.AddWithValue("_GownId", rentals.GownId);
                    com.Parameters.AddWithValue("_UserId", rentals.UserId);
                    com.Parameters.AddWithValue("_Date", rentals.Date);
                    com.Parameters.AddWithValue("_DueDate", rentals.DueDate);
                    com.Parameters.AddWithValue("_RentalFee", rentals.RentalFee);
                    com.Parameters.AddWithValue("_Status", rentals.Status);
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

        public async Task<int>Returned(Rentals rentals)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("Returned", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Id", rentals.Id);
                    com.Parameters.AddWithValue("_GownId", rentals.GownId);
                    com.Parameters.AddWithValue("_UserId", rentals.UserId);
                    com.Parameters.AddWithValue("_Date", rentals.Date);
                    com.Parameters.AddWithValue("_DueDate", rentals.DueDate);
                    com.Parameters.AddWithValue("_RentalFee", rentals.RentalFee);
                    com.Parameters.AddWithValue("_Status", rentals.Status);
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


﻿using Microsoft.Extensions.Options;
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
                            Status = rdr["Status"].ToString()
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

        public async Task<List<Gowns>> PendingGowns()
        {
            List<Gowns> gown = new List<Gowns>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewPendingGowns", con)
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
                            Status = rdr["Status"].ToString()
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

        public async Task<List<Gowns>> GetGownsByType(string type)
        {
            List<Gowns> gown = new List<Gowns>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("GetGownsByType", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Type", type);
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
                            Status = rdr["Status"].ToString()
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

        public async Task<List<Gowns>> GetGownsByColor(string type)
        {
            List<Gowns> gown = new List<Gowns>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("GetGownsByColor", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Color", type);
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
                            Status = rdr["Status"].ToString()
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

        public async Task<List<Gowns>> GetGownsBySize(string size)
        {
            List<Gowns> gown = new List<Gowns>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("GetGownsBySize", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Size", size);
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
                            Status = rdr["Status"].ToString()
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

        public async Task<List<Gowns>> SearchGown(string search)
        {
            List<Gowns> gown = new List<Gowns>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchGown", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("search", search);
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
                            Status = rdr["Status"].ToString()
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

        public async Task<List<Gowns>> AvailableGowns()
        {
            List<Gowns> gown = new List<Gowns>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewAvailableGowns", con)
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
                            Status = rdr["Status"].ToString()
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
                    com.Parameters.AddWithValue("_Status", gown.Status);
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
                    com.Parameters.AddWithValue("_Status", gown.Status);
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

        public async Task<int> CountAvailableGowns()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("CountAvailableGowns", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> CountPendingGowns()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("CountPendingGowns", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> CountRentedGowns()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("CountRentedGowns", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task<int> CountReturnedGowns()
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("CountReturnedGowns", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                return Convert.ToInt32(await com.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }


    }
}

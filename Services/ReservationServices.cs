using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using RentalSystem.Class;
using RentalSystem.Models;
using System.Data;

namespace RentalSystem.Services
{
    public class ReservationServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;

        public ReservationServices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        public async Task<List<Reservation>> Reservations()
        {
            List<Reservation> reservation = new List<Reservation>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ViewReservation", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        reservation.Add(new Reservation
                        {
                            Id = rdr["Id"].ToString(),
                            Fullname = rdr["Fullname"].ToString(),
                            Date = Convert.ToDateTime(rdr["Date"]),
                            PickupDate = Convert.ToDateTime(rdr["PickupDate"]),
                            Type = rdr["Type"].ToString(),
                            Photo = rdr["Photo"] as byte[],
                            Name = rdr["Name"].ToString(),
                            Color = rdr["Color"].ToString(),
                            Size = rdr["Size"].ToString(),
                            PaymentMethod = rdr["PaymentMethod"].ToString(),
                            ReservationFee = Convert.ToDouble(rdr["ReservationFee"]),
                            Receipt = rdr["Receipt"] as byte[],
                            Fee = Convert.ToDouble(rdr["Fee"]),
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
            return reservation;
        }

        public async Task<int> AddReservation(Reservation reservation)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("AddReservation", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_Id", reservation.Id);
                    com.Parameters.AddWithValue("_GownId", reservation.GownId);
                    com.Parameters.AddWithValue("_UserId", reservation.UserId);
                    com.Parameters.AddWithValue("_Date", reservation.Date);
                    com.Parameters.AddWithValue("_PickupDate", reservation.PickupDate);
                    com.Parameters.AddWithValue("_PaymentMethod", reservation.PaymentMethod);
                    com.Parameters.AddWithValue("_ReservationFee", reservation.ReservationFee);
                    com.Parameters.AddWithValue("_Receipt", reservation.Receipt);
                    com.Parameters.AddWithValue("_Status", reservation.Status);
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

        public async Task<int> ApproveReservation(Reservation reservation)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("ApproveReservation", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.AddWithValue("_ReservationId", reservation.Id);
                    com.Parameters.AddWithValue("_Status", reservation.Status);
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

        public async Task<List<Reservation>> SearchReservation(string search)
        {
            List<Reservation> reservation = new List<Reservation>();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                try
                { 
                    await con.OpenAsync().ConfigureAwait(false);
                    var com = new MySqlCommand("SearchReservation", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("search", search);
                    com.Parameters.AddWithValue("@searchWildcard", $"{search}%");
                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {
                        reservation.Add(new Reservation
                        {
                            Id = rdr["Id"].ToString(),
                            Fullname = rdr["Fullname"].ToString(),
                            Date = Convert.ToDateTime(rdr["Date"]),
                            PickupDate = Convert.ToDateTime(rdr["PickupDate"]),
                            Type = rdr["Type"].ToString(),
                            Photo = rdr["Photo"] as byte[],
                            Name = rdr["Name"].ToString(),
                            Color = rdr["Color"].ToString(),
                            Size = rdr["Size"].ToString(),
                            PaymentMethod = rdr["PaymentMethod"].ToString(),
                            ReservationFee = Convert.ToDouble(rdr["ReservationFee"]),
                            Receipt = rdr["Receipt"] as byte[],
                            Fee = Convert.ToDouble(rdr["Fee"]),
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
            return reservation;
        }

    }
}

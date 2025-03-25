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
            return reservation;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using DriverDistributor.Entities;
using DriverDistributor.Entities.Dtos;
using DriverDistributor.Entities.Shipment;

namespace DriverDistributor.Api.Controllers
{
    public class HandleAccessFile
    {
        private static readonly string pathAccess =
            @"C:\Users\a.rahmanian\RiderProjects\DriverDistributor\DriverDistributor.Entities\Database\Database1.accdb";

        private static readonly string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pathAccess};";

        public List<Shipment> ReturnAccess()
        {
            var result = new List<Shipment>();
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                var command = new OleDbCommand("SELECT * FROM Shipments s JOIN ShipmentNumbers sn ON s.id=sn.ShipmentId", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Shipment
                        {
                            Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                            DriverName = reader["Driver"]?.ToString(),
                            DistributorName = reader["Distributor"]?.ToString(),
                            Date = reader["ShipmentDate"] != DBNull.Value ? (DateTime)reader["ShipmentDate"] : default,
                            InvoiceAmount = reader["InvoiceAmount"] != DBNull.Value ? (decimal)reader["InvoiceAmount"] : 0,
                            InvoiceCount = reader["InvoiceCount"] != DBNull.Value ? (int)reader["InvoiceCount"] : 0,
                            Route = reader["Route"]?.ToString(),
                            Time = reader["Time"] != DBNull.Value ? (int)reader["Time"] : 0,
                            Warehouse = reader["Warehouse"]?.ToString(),
                        });
                        var a = result.Where(r => r.Id == (int)(reader["Id"])).Select(c => c.ShipmentNumbers);
                        a.
                    }
                }
            }

            return result ?? new List<Shipment>();
        }

        public List<Shipment> ReturnFile()
        {
            var shipments = new QueryExecutor().executeQuery("SELECT * FROM Shipments",);
        }
    }
}
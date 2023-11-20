#region Usings
using Dapper;
using PrzegladyRemonty.Database;
using PrzegladyRemonty.Database.DTOs;
using PrzegladyRemonty.Interfaces;
using PrzegladyRemonty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace PrzegladyRemonty.Services.Providers
{
    public class TransporterProvider : IProvider<Transporter>
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
                INSERT INTO
                transporter (Name, Active, Area, TransporterType)
                VALUES (@Name, True, @Area, @TransporterType)
                ";
        private const string _deleteSQL = @"
                DELETE
                FROM transporter
                WHERE Id = @Id
                ";
        private const string _getAllSQL = @"
                SELECT *
                FROM transporter
                ";
        private const string _getOneSQL = @"
                SELECT *
                FROM transporter
                WHERE Id = @Id
                ";
        private const string _updateSQL = @"
                UPDATE  transporter
                SET 
                    Name = @Name,
                    Active = @Active,
                    Area = @Area,
                    TransporterType = @TransporterType,
                    LastMaintenance = @LastMaintenance
                WHERE Id = @Id
                ";
        #endregion

        public TransporterProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(Transporter transporter)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Name = transporter.Name,
                Area = transporter.AreaId,
                TransporterType = transporter.TransporterTypeId
            };
            await database.ExecuteAsync(_createSQL, parameters);
        }
        public async Task Delete(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            await database.ExecuteAsync(_deleteSQL, parameters);
        }
        public async Task<IEnumerable<Transporter>> GetAll()
        {
            using IDbConnection database = _dbContextFactory.Connect();
            IEnumerable<TransporterDTO> transporterDTOs = await database.QueryAsync<TransporterDTO>(_getAllSQL);
            return transporterDTOs.Select(ToTransporter);
        }
        public Transporter GetById(int id)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = id
            };
            TransporterDTO transporterDTO = database.QuerySingleOrDefault<TransporterDTO>(_getOneSQL, parameters);
            return ToTransporter(transporterDTO);
        }
        public async void Update(Transporter transporter)
        {
            using IDbConnection database = _dbContextFactory.Connect();
            object parameters = new
            {
                Id = transporter.Id,
                Name = transporter.Name,
                Active = transporter.Active,
                Area = transporter.AreaId,
                TransporterType = transporter.TransporterTypeId,
                LastMaintenance = transporter.LastMaintenance
            };
            await database.ExecuteAsync(_updateSQL, parameters);
        }
        #endregion

        private static Transporter ToTransporter(TransporterDTO transporterDTO)
        {
            return new Transporter(
                transporterDTO.Id,
                transporterDTO.Name,
                transporterDTO.Active,
                transporterDTO.Area,
                transporterDTO.TransporterType,
                MaintenanceDateParser(transporterDTO.LastMaintenance));
        }

        private static DateOnly MaintenanceDateParser(string lastMaintenance)
        {
            if (lastMaintenance == null)
            {
                return DateOnly.FromDayNumber(0);
            }
            return DateOnly.Parse(lastMaintenance);
        }
    }
}
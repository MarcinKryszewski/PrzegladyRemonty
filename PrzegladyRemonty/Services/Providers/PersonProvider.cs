#region Usings
using Dapper;
using PrzegladyRemonty.Database;
using PrzegladyRemonty.Database.DTOs;
using PrzegladyRemonty.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace PrzegladyRemonty.Services.Providers
{
    public class PersonProvider : IDatabaseDTOProvider<Person> //where Person : Person
    {
        private readonly DatabaseConnectionFactory _dbContextFactory;

        #region SQLCommands
        private const string _createSQL = @"
            INSERT INTO
            person (Login, Name, Surname, Active)
            VALUES (@Login, @Name, @Surname, True)
            ";
        private const string _deleteSQL = @"
            DELETE
            FROM person
            WHERE Id = @Id
            ";
        private const string _getAllSQL = @"
            SELECT *
            FROM person
            ";
        private const string _getOneSQL = @"
            SELECT *
            FROM person
            WHERE Id = @Id
            ";
        private const string _updateSQL = @"
            UPDATE  person
            SET (
                Login = @Login, 
                Name = @Name,
                Surname = @Surname, 
                Active = @Active
            )
            WHERE Id = @Id
            ";
        private const string _countByName = @"
            SELECT COUNT(*)
            FROM person
            WHERE Name = @Name
            ";
        #endregion

        public PersonProvider(DatabaseConnectionFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region CRUD
        public async void Create(Person person)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Login = person.Login,
                    Name = person.Name,
                    Surname = person.Surname
                };
                await database.ExecuteAsync(_createSQL, parameters);
            }
        }
        public async void Delete(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                await database.ExecuteAsync(_deleteSQL, parameters);
            }
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                IEnumerable<PersonDTO> personDTOs = await database.QueryAsync<PersonDTO>(_getAllSQL);
                return personDTOs.Select(ToPerson);
            }
        }
        public Person GetById(int id)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = id
                };
                PersonDTO personDTO = database.QuerySingleOrDefault<PersonDTO>(_getOneSQL, parameters);
                return ToPerson(personDTO);
            }
        }
        public async void Update(Person person)
        {
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Id = person.Id,
                    Login = person.Login,
                    Name = person.Name,
                    Surname = person.Surname,
                    Active = person.Active
                };
                await database.ExecuteAsync(_updateSQL, parameters);
            }
        }
        #endregion

        public bool Exists(string name)
        {
            int count = 0;
            using (IDbConnection database = _dbContextFactory.Connect())
            {
                object parameters = new
                {
                    Name = name
                };
                count = database.ExecuteScalar<int>(_countByName, parameters);
            }
            if (count == 1) return true;
            if (count > 1) return true; //TODO: this is an error, requires handler
            return false;
        }

        private static Person ToPerson(PersonDTO personDTO)
        {
            Person person = new(
                personDTO.Id,
                personDTO.Login,
                personDTO.Name,
                personDTO.Surname,
                personDTO.Active
            );
            return (Person)person;
        }
    }
}
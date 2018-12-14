using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DatabaseContext
{
    class DbContextFactory : IDisposable
    {
        private DbContext _dbContext;

        /// <summary>
        /// Lấy đối tượng DbContext
        /// </summary>
        public DbContext Context {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new DbContext();
                }
                return _dbContext;
            }
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}

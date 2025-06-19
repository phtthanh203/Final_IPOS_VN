using IPOS.DataAccess;
using IPOS.DB;
using System.Collections.Generic;

namespace IPOS.Business
{
    public class TableService
    {
        private readonly TableRepository _repo = new TableRepository();

        public List<Table_Details> GetAllTables()
        {
            return _repo.GetAllTables();
        }

        public bool IsTableOccupied(int tableId)
        {
            return _repo.IsTableOccupied(tableId);
        }
    }
}

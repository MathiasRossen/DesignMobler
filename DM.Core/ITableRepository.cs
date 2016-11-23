namespace DM.Core
{
    interface ITableRepository
    {
        void SaveTable(Table table);
        Table LoadTable(int wareId);
    }
}

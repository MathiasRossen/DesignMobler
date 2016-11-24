namespace DM.Core
{
    public interface IBoardRepository
    {
        void SaveBoard(Board board);
        Board LoadBoard(int wareId);
    }
}

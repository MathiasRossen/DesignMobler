using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Core
{
    public class BoardRepository : IBoardRepository
    {
        private List<Board> boardList;

        public BoardRepository()
        {
            boardList = new List<Board>();

            SaveBoard(new Board(1000, 100, 100));
            SaveBoard(new Board(1100, 200, 150));
            SaveBoard(new Board(1200, 400, 300));
        }

        public Board LoadBoard(int wareId)
        {
            if (boardList.Exists(x => x.WareId == wareId))
                return boardList.Find(x => x.WareId == wareId);
            else
                return new Board(wareId, 0, 0);
        }

        public Board LoadBoard(Board board)
        {
            return boardList.Find(x => x.WareId == board.WareId);
        }

        public void SaveBoard(Board board)
        {
            boardList.Add(board);
        }


    }
}

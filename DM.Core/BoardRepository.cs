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

            SaveBoard(new Board(1000, 100, 100, Surfaces.H1, true));
            SaveBoard(new Board(1100, 200, 150, Surfaces.H1, true));
            SaveBoard(new Board(1200, 400, 300, Surfaces.H1, true));
        }

        public Board LoadBoard(int wareId)
        {
            if (BoardExists(wareId))
                return boardList.Find(x => x.WareId == wareId);
            else
                return new Board(wareId, 0, 0, Surfaces.H1, true);
        }

        public Board LoadBoard(Board board)
        {
            return LoadBoard(board.WareId);
        }

        public void SaveBoard(Board board)
        {
            if (BoardExists(board.WareId))
            {
                FindBoard(board).Length = board.Length;
                FindBoard(board).Width = board.Width;
                FindBoard(board).Surface = board.Surface;
                FindBoard(board).Extension = board.Extension;
            }
            else
                boardList.Add(board);
        }

        private bool BoardExists(int wareId)
        {
            return boardList.Exists(x => x.WareId == wareId);
        }

        private Board FindBoard(Board board)
        {
            return boardList.Find(x => x.WareId == board.WareId);
        }


    }
}

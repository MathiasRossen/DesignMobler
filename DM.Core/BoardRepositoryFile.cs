using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DM.Core
{
    public class BoardRepositoryFile : IBoardRepository
    {
        private string path;

        public BoardRepositoryFile(string path)
        {
            this.path = path;
            Directory.CreateDirectory(path);
        }

        public Board LoadBoard(int wareId)
        {
            Board boardToLoad = new Board(wareId, 0, 0, Surfaces.H1, true);

            try
            {
                using (StreamReader file = new StreamReader(path + "/" + wareId + ".txt"))
                {
                    boardToLoad.WareId = int.Parse(file.ReadLine());
                    boardToLoad.Width = int.Parse(file.ReadLine());
                    boardToLoad.Length = int.Parse(file.ReadLine());
                    boardToLoad.Extension = bool.Parse(file.ReadLine());
                    boardToLoad.Surface = (Surfaces)int.Parse(file.ReadLine());
                }
            }
            catch (Exception)
            {

            }

            return boardToLoad;
        }

        public void SaveBoard(Board board)
        {
            using(StreamWriter file = new StreamWriter(path + "/" + board.WareId + ".txt"))
            {
                file.WriteLine(board.WareId);
                file.WriteLine(board.Width);
                file.WriteLine(board.Length);
                file.WriteLine(board.Extension);
                file.WriteLine((int)board.Surface);
            }
        }
    }
}

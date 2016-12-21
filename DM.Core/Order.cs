﻿using System.Collections.Generic;
using System.Linq;


namespace DM.Core
{
    public class Order
    {
        List<Board> boards = new List<Board>();

        public void AddBoard(Board board)
        {
            if (!boards.Exists(x => x.Equals(board)))
                boards.Add(board);
            else
            {
                boards.Find(x => x.WareId == board.WareId).Quantity += board.Quantity;
            }
        }

        public void AddBoard(Board board, IBoardRepository br)
        {
            EditBoard(board, br);
            AddBoard(board);
        }

        public void EditQuantity(int wareId, int newQuantity)
        {
            boards.Find(x => x.WareId == wareId).Quantity = newQuantity;
        }

        public void RemoveBoard(int index)
        {
            boards.RemoveAt(index);
        }

        public void RemoveBoard(Board board)
        {
            boards.RemoveAll(x => x.Equals(board));
        }

        public void ClearOrder()
        {
            boards.Clear();
        }
        public Board GetBoard()
        {
            return boards.First();
        }

        public Board GetBoard(int wareId)
        {
            return boards.Find(x => x.WareId == wareId);
        }

        public List<Board> GetBoards()
        {
            return boards;
        }

        public void EditBoard(Board board, IBoardRepository br)
        {
            if (boards.Exists(x => x.WareId == board.WareId))
            {
                int index = boards.FindIndex(x => x.WareId == board.WareId);
                boards[index] = board;
                br.SaveBoard(board);
            }
        }

             
        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj.ToString() == ToString())
                return true;
            return false;
        }

        public override string ToString()
        {
            return boards.Count.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}

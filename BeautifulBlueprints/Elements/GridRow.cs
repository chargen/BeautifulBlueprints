﻿
using System;
using BeautifulBlueprints.Layout;

namespace BeautifulBlueprints.Elements
{
    public class GridRow
        : IEquatable<GridRow>, ISizeable
    {
        public decimal Size { get; private set; }

        public SizeMode Mode { get; private set; }

        public GridRow(decimal size, SizeMode mode)
        {
            Size = size;
            Mode = mode;
        }

        public bool Equals(GridRow other)
        {
            return other.Size.IsEqualTo(Size)
                && other.Mode == Mode;
        }

        public override bool Equals(object obj)
        {
            var row = obj as GridRow;
            if (row != null)
                return Equals(row);

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Size.GetHashCode() * 397) ^ (int)Mode;
            }
        }

        internal GridRowContainer Wrap()
        {
            return new GridRowContainer
            {
                Size = Size,
                Mode = Mode
            };
        }
    }

    internal class GridRowContainer
    {
        public decimal Size { get; set; }

        public SizeMode Mode { get; set; }

        public GridRow Unwrap()
        {
            return new GridRow(Size, Mode);
        }
    }
}

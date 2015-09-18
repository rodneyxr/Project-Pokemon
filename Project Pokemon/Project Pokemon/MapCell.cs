﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Pokemon {
    class MapCell {

        public List<int> BaseTiles = new List<int>();
        public int TileID {
            get { return BaseTiles.Count > 0 ? BaseTiles[0] : 0; }
            set {
                if (BaseTiles.Count > 0)
                    BaseTiles[0] = value;
                else
                    AddBaseTile(value);
            }
        }

        public MapCell(int tileID) {
            TileID = tileID;
        }

        public void AddBaseTile(int tileID) {
            BaseTiles.Add(tileID);
        }

    }

} // END NAMESPACE

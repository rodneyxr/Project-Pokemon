using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Pokemon {
    class TileMap {

        /* Declarations */
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 50;
        public int MapHeight = 50;

        /* Constructor */
        public TileMap() {

            for (int y = 0; y < MapHeight; y++) {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                    thisRow.Columns.Add(new MapCell(186)); // 186 - Grass
                Rows.Add(thisRow);
            }

            // Create Sample Map Data
            Rows[0].Columns[3].TileID = 605;
            Rows[0].Columns[4].TileID = 605;
            Rows[0].Columns[5].TileID = 605;
            Rows[0].Columns[6].TileID = 605;
            Rows[0].Columns[7].TileID = 605;

            Rows[1].Columns[3].TileID = 3;
            Rows[1].Columns[4].TileID = 605;
            Rows[1].Columns[5].TileID = 605;
            Rows[1].Columns[6].TileID = 605;
            Rows[1].Columns[7].TileID = 605;

            Rows[2].Columns[2].TileID = 3;
            Rows[2].Columns[3].TileID = 605;
            Rows[2].Columns[4].TileID = 605;
            Rows[2].Columns[5].TileID = 605;
            Rows[2].Columns[6].TileID = 605;
            Rows[2].Columns[7].TileID = 605;

            Rows[3].Columns[2].TileID = 3;
            Rows[3].Columns[3].TileID = 605;
            Rows[3].Columns[4].TileID = 605;
            Rows[3].Columns[5].TileID = 2;
            Rows[3].Columns[6].TileID = 2;
            Rows[3].Columns[7].TileID = 2;

            Rows[4].Columns[2].TileID = 3;
            Rows[4].Columns[3].TileID = 605;
            Rows[4].Columns[4].TileID = 605;
            Rows[4].Columns[5].TileID = 2;
            Rows[4].Columns[6].TileID = 2;
            Rows[4].Columns[7].TileID = 2;

            Rows[5].Columns[2].TileID = 3;
            Rows[5].Columns[3].TileID = 605;
            Rows[5].Columns[4].TileID = 605;
            Rows[5].Columns[5].TileID = 2;
            Rows[5].Columns[6].TileID = 2;
            Rows[5].Columns[7].TileID = 2;

            // Layers - Pokemon Center
            Rows[15].Columns[20].AddBaseTile(244);
            Rows[15].Columns[21].AddBaseTile(245);
            Rows[15].Columns[22].AddBaseTile(246);
            Rows[15].Columns[23].AddBaseTile(247);
            Rows[15].Columns[24].AddBaseTile(248);

            Rows[16].Columns[20].AddBaseTile(305);
            Rows[16].Columns[21].AddBaseTile(306);
            Rows[16].Columns[22].AddBaseTile(307);
            Rows[16].Columns[23].AddBaseTile(308);
            Rows[16].Columns[24].AddBaseTile(309);

            Rows[17].Columns[20].AddBaseTile(366);
            Rows[17].Columns[21].AddBaseTile(367);
            Rows[17].Columns[22].AddBaseTile(368);
            Rows[17].Columns[23].AddBaseTile(369);
            Rows[17].Columns[24].AddBaseTile(370);

            Rows[18].Columns[20].AddBaseTile(427);
            Rows[18].Columns[21].AddBaseTile(428);
            Rows[18].Columns[22].AddBaseTile(429);
            Rows[18].Columns[23].AddBaseTile(430);
            Rows[18].Columns[24].AddBaseTile(431);

            Rows[19].Columns[20].AddBaseTile(488);
            Rows[19].Columns[21].AddBaseTile(489);
            Rows[19].Columns[22].AddBaseTile(490);
            Rows[19].Columns[23].AddBaseTile(491);
            Rows[19].Columns[24].AddBaseTile(492);

            //Rows[3].Columns[6].AddBaseTile(25);
            //Rows[5].Columns[6].AddBaseTile(24);

            //Rows[3].Columns[7].AddBaseTile(31);
            //Rows[4].Columns[7].AddBaseTile(26);
            //Rows[5].Columns[7].AddBaseTile(29);

            //Rows[4].Columns[6].AddBaseTile(104);

            // End Create Sample Map Data

        }

    } // End Class TileMap

    class MapRow {
        public List<MapCell> Columns = new List<MapCell>();
    }
}

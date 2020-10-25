using McConahie.Roulette.Models;
using System;
using System.Collections.Generic;

namespace McConahie.Roulette
{
    public class PositionClassifier
    {
        private readonly NameClassifier _nameClassifier;
        private readonly ResultClassifier _resultClassifier;

        public List<int> PossiblePositions { get; }
        public List<int> PossibleOutsidePositions { get; }

        public PositionClassifier()
        {
            PossiblePositions = new List<int>();
            PossibleOutsidePositions = new List<int>();

            for(int i = 0; i < 161; i++)
            {
                PossiblePositions.Add(i);
            }

            PossibleOutsidePositions.Add(50);
            PossibleOutsidePositions.Add(89);
            PossibleOutsidePositions.Add(127);
            PossibleOutsidePositions.Add(152);
            PossibleOutsidePositions.Add(153);
            PossibleOutsidePositions.Add(154);
            PossibleOutsidePositions.Add(155);
            PossibleOutsidePositions.Add(156);
            PossibleOutsidePositions.Add(157);
            PossibleOutsidePositions.Add(158);
            PossibleOutsidePositions.Add(159);
            PossibleOutsidePositions.Add(160);

            _nameClassifier = new NameClassifier();
            _resultClassifier = new ResultClassifier();
        }

        public Classification ClassifyPosition(int positionId)
        {
            if(positionId > -1 && positionId < 38)
            {
                string positionName = positionId == 37 ? "00" : positionId.ToString();
                return _resultClassifier.ClassifyResult(positionId).Find(r => r.Name == positionName);
            }

            switch (positionId)
            {
                case 38:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_00_3");
                    }
                case 39:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_3_6");
                    }
                case 40:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_3_6");
                    }
                case 41:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_6_9");
                    }
                case 42:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_9_12");
                    }
                case 43:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_12_15");
                    }
                case 44:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_15_18");
                    }
                case 45:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_18_21");
                    }
                case 46:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_21_24");
                    }
                case 47:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_24_27");
                    }
                case 48:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_27_30");
                    }
                case 49:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_33_36");
                    }
                case 50:
                    {
                        return _nameClassifier.GetClassificationByName("TOP_COLUMN");
                    }
                case 51:
                    {
                        return _nameClassifier.GetClassificationByName("TRIO_00_3_2");
                    }
                case 52:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_3_2");
                    }
                case 53:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_3_6_2_5");
                    }
                case 54:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_6_5");
                    }
                case 55:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_6_9_5_8");
                    }
                case 56:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_9_8");
                    }
                case 57:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_9_12_8_11");
                    }
                case 58:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_12_11");
                    }
                case 59:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_12_15_11_14");
                    }
                case 60:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_15_14");
                    }
                case 61:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_15_18_14_17");
                    }
                case 62:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_18_17");
                    }
                case 63:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_18_21_17_20");
                    }
                case 64:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_21_20");
                    }
                case 65:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_21_24_20_23");
                    }
                case 66:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_24_23");
                    }
                case 67:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_24_27_23_26");
                    }
                case 68:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_27_26");
                    }
                case 69:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_27_30_26_29");
                    }
                case 70:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_30_29");

                    }
                case 71:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_30_33_29_32");

                    }
                case 72:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_33_32");

                    }
                case 73:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_33_36_32_35");

                    }
                case 74:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_36_35");

                    }
                case 75:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_00_2");

                    }
                case 76:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_00_0");

                    }
                case 77:
                    {
                        return _nameClassifier.GetClassificationByName("TRIO_00_2_0");

                    }
                case 78:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_2_5");

                    }
                case 79:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_5_8");

                    }
                case 80:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_8_11");

                    }
                case 81:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_11_14");

                    }
                case 82:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_14_17");

                    }
                case 83:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_17_20");

                    }
                case 84:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_20_23");

                    }
                case 85:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_23_26");

                    }
                case 86:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_26_29");

                    }
                case 87:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_29_32");

                    }
                case 88:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_32_35");

                    }
                case 89:
                    {
                        return _nameClassifier.GetClassificationByName("MIDDLE_COLUMN");

                    }
                case 90:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_0_2");

                    }
                case 91:
                    {
                        return _nameClassifier.GetClassificationByName("TRIO_2_0_1");

                    }
                case 92:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_2_1");

                    }
                case 93:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_2_5_1_4");

                    }
                case 94:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_5_4");

                    }
                case 95:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_5_8_4_7");

                    }
                case 96:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_8_7");

                    }
                case 97:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_8_11_7_10");

                    }
                case 98:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_11_10");

                    }
                case 99:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_11_14_10_13");

                    }
                case 100:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_14_13");

                    }
                case 101:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_14_17_13_16");

                    }
                case 102:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_17_16");

                    }
                case 103:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_17_20_16_19");

                    }
                case 104:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_20_19");

                    }
                case 105:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_20_23_19_22");

                    }
                case 106:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_23_22");

                    }
                case 107:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_23_26_22_25");

                    }
                case 108:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_26_25");

                    }
                case 109:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_26_29_25_28");

                    }
                case 110:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_29_28");

                    }
                case 111:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_29_32_28_31");

                    }
                case 112:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_32_31");

                    }
                case 113:
                    {
                        return _nameClassifier.GetClassificationByName("CORNER_32_35_31_34");

                    }
                case 114:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_35_34");

                    }
                case 115:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_0_1");

                    }
                case 116:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_1_4");

                    }
                case 117:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_4_7");

                    }
                case 118:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_7_10");

                    }
                case 119:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_10_13");

                    }
                case 120:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_13_16");

                    }
                case 121:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_16_19");

                    }
                case 122:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_19_22");

                    }
                case 123:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_22_25");

                    }
                case 124:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_25_28");

                    }
                case 125:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_28_31");

                    }
                case 126:
                    {
                        return _nameClassifier.GetClassificationByName("SPLIT_31_34");

                    }
                case 127:
                    {
                        return _nameClassifier.GetClassificationByName("BOTTOM_COLUMN");

                    }
                case 128:
                    {
                        return _nameClassifier.GetClassificationByName("BASKET");

                    }
                case 129:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_1");

                    }
                case 130:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_1_4");

                    }
                case 131:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_4");

                    }
                case 132:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_4_7");

                    }
                case 133:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_7");

                    }
                case 134:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_7_10");

                    }
                case 135:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_10");

                    }
                case 136:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_10_13");

                    }
                case 137:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_13");

                    }
                case 138:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_13_16");
                    }
                case 139:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_16");
                    }
                case 140:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_16_19");
                    }
                case 141:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_19");

                    }
                case 142:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_19_22");

                    }
                case 143:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_22");

                    }
                case 144:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_22_25");

                    }
                case 145:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_25");

                    }
                case 146:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_25_28");

                    }
                case 147:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_28");

                    }
                case 148:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_28_31");

                    }
                case 149:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_31");

                    }
                case 150:
                    {
                        return _nameClassifier.GetClassificationByName("DOUBLE_STREET_31_34");
                    }
                case 151:
                    {
                        return _nameClassifier.GetClassificationByName("STREET_34");

                    }
                case 152:
                    {
                        return _nameClassifier.GetClassificationByName("FIRST_DOZEN");

                    }
                case 153:
                    {
                        return _nameClassifier.GetClassificationByName("SECOND_DOZEN");

                    }
                case 154:
                    {
                        return _nameClassifier.GetClassificationByName("THIRD_DOZEN");

                    }
                case 155:
                    {
                        return _nameClassifier.GetClassificationByName("LOW");

                    }
                case 156:
                    {
                        return _nameClassifier.GetClassificationByName("EVEN");

                    }
                case 157:
                    {
                        return _nameClassifier.GetClassificationByName("RED");

                    }
                case 158:
                    {
                        return _nameClassifier.GetClassificationByName("BLACK");

                    }
                case 159:
                    {
                        return _nameClassifier.GetClassificationByName("ODD");

                    }
                case 160:
                    {
                        return _nameClassifier.GetClassificationByName("HIGH");

                    }
                default:
                    {
                        throw new ArgumentException("Invalid Position Id");
                    }
            }
        }
    }
}

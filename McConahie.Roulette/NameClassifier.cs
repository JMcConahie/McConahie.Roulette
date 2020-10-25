using McConahie.Roulette.Models;

namespace McConahie.Roulette
{
    public class NameClassifier
    {
        public Classification GetClassificationByName(string name)
        {
            int payoutMultiplier;
            name = name.ToUpper();

            switch (name)
            {
                case "00":
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                case "17":
                case "18":
                case "19":
                case "20":
                case "21":
                case "22":
                case "23":
                case "24":
                case "25":
                case "26":
                case "27":
                case "28":
                case "29":
                case "30":
                case "31":
                case "32":
                case "33":
                case "34":
                case "35":
                case "36":
                    {
                        payoutMultiplier = 36;
                        break;
                    }
                case "SPLIT_00_3":
                case "SPLIT_00_2":
                case "SPLIT_00_0":
                case "SPLIT_0_2":
                case "SPLIT_0_1":
                case "SPLIT_3_6":
                case "SPLIT_3_2":
                case "SPLIT_6_9":
                case "SPLIT_6_5":
                case "SPLIT_9_12":
                case "SPLIT_9_8":
                case "SPLIT_12_15":
                case "SPLIT_12_11":
                case "SPLIT_15_18":
                case "SPLIT_15_14":
                case "SPLIT_18_21":
                case "SPLIT_18_17":
                case "SPLIT_21_24":
                case "SPLIT_21_20":
                case "SPLIT_24_27":
                case "SPLIT_24_23":
                case "SPLIT_27_30":
                case "SPLIT_27_26":
                case "SPLIT_30_33":
                case "SPLIT_30_29":
                case "SPLIT_33_36":
                case "SPLIT_33_32":
                case "SPLIT_36_35":
                case "SPLIT_2_5":
                case "SPLIT_2_1":
                case "SPLIT_5_8":
                case "SPLIT_5_4":
                case "SPLIT_8_11":
                case "SPLIT_8_7":
                case "SPLIT_11_14":
                case "SPLIT_11_10":
                case "SPLIT_14_17":
                case "SPLIT_14_13":
                case "SPLIT_17_20":
                case "SPLIT_17_16":
                case "SPLIT_20_23":
                case "SPLIT_20_19":
                case "SPLIT_23_26":
                case "SPLIT_23_22":
                case "SPLIT_26_29":
                case "SPLIT_26_25":
                case "SPLIT_29_32":
                case "SPLIT_29_28":
                case "SPLIT_32_35":
                case "SPLIT_32_31":
                case "SPLIT_35_34":
                case "SPLIT_1_4":
                case "SPLIT_4_7":
                case "SPLIT_7_10":
                case "SPLIT_10_13":
                case "SPLIT_13_16":
                case "SPLIT_16_19":
                case "SPLIT_19_22":
                case "SPLIT_22_25":
                case "SPLIT_25_28":
                case "SPLIT_28_31":
                case "SPLIT_31_34":
                    {
                        payoutMultiplier = 18;
                        break;
                    }
                case "TRIO_00_3_2":
                case "TRIO_00_2_0":
                case "TRIO_2_0_1":
                case "STREET_1":
                case "STREET_4":
                case "STREET_7":
                case "STREET_10":
                case "STREET_13":
                case "STREET_16":
                case "STREET_19":
                case "STREET_22":
                case "STREET_25":
                case "STREET_28":
                case "STREET_31":
                case "STREET_34":
                    {
                        payoutMultiplier = 12;
                        break;
                    }
                case "CORNER_3_6_2_5":
                case "CORNER_2_5_1_4":
                case "CORNER_6_9_5_8":
                case "CORNER_5_8_4_7":
                case "CORNER_9_12_8_11":
                case "CORNER_8_11_7_10":
                case "CORNER_12_15_11_14":
                case "CORNER_11_14_10_13":
                case "CORNER_15_18_14_17":
                case "CORNER_14_17_13_16":
                case "CORNER_18_21_17_20":
                case "CORNER_17_20_16_19":
                case "CORNER_21_24_20_23":
                case "CORNER_20_23_19_22":
                case "CORNER_24_27_23_26":
                case "CORNER_23_26_22_25":
                case "CORNER_27_30_26_29":
                case "CORNER_26_29_25_28":
                case "CORNER_30_33_29_32":
                case "CORNER_29_32_28_31":
                case "CORNER_33_36_32_35":
                case "CORNER_32_35_31_34":
                    {
                        payoutMultiplier = 9;
                        break;
                    }
                case "BASKET":
                    {
                        payoutMultiplier = 7;
                        break;
                    }
                case "DOUBLE_STREET_1_4":
                case "DOUBLE_STREET_4_7":
                case "DOUBLE_STREET_7_10":
                case "DOUBLE_STREET_10_13":
                case "DOUBLE_STREET_13_16":
                case "DOUBLE_STREET_16_19":
                case "DOUBLE_STREET_19_22":
                case "DOUBLE_STREET_22_25":
                case "DOUBLE_STREET_25_28":
                case "DOUBLE_STREET_28_31":
                case "DOUBLE_STREET_31_34":
                    {
                        payoutMultiplier = 6;
                        break;
                    }
                case "TOP_COLUMN":
                case "MIDDLE_COLUMN":
                case "BOTTOM_COLUMN":
                case "FIRST_DOZEN":
                case "SECOND_DOZEN":
                case "THIRD_DOZEN":
                    {
                        payoutMultiplier = 3;
                        break;
                    }
                case "RED":
                case "BLACK":
                case "HIGH":
                case "LOW":
                case "EVEN":
                case "ODD":
                    {
                        payoutMultiplier = 2;
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }

            return new Classification()
            {
                Name = name,
                PayoutMultiplier = payoutMultiplier
            };
        }
    }
}

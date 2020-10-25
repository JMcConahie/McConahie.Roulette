using McConahie.Roulette.Models;
using System;
using System.Collections.Generic;

namespace McConahie.Roulette
{
    public class ResultClassifier
    {
        private readonly NameClassifier _nameClassifier;

        public ResultClassifier()
        {
            _nameClassifier = new NameClassifier();
        }

        public List<Classification> ClassifyResult(int result)
        {
            List<Classification> classifications = new List<Classification>();

            classifications.AddRange(GetCorners(result));

            if(result == 37)
            {
                classifications.Add(_nameClassifier.GetClassificationByName("00"));
                classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_00_3"));
                classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_00_2"));
                classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_00_0"));
            }
            else
            {
                switch(result)
                {
                    case 0:
                        {
                            classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_00_0"));
                            classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_0_2"));
                            classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_0_1"));
                            break;
                        }
                    case 1:
                        {
                            classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_0_1"));
                            break;
                        }
                    case 2:
                        {
                            classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_00_2"));
                            classifications.Add(_nameClassifier.GetClassificationByName("SPLIT_0_2"));
                            break;
                        }
                    default:
                        break;
                }

                classifications.Add(new Classification()
                {
                    Name = result.ToString(),
                    PayoutMultiplier = 36
                });
            }

            if(IsTopColumn(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "TOP_COLUMN",
                    PayoutMultiplier = 3
                });
            }
            
            if(IsMiddleColumn(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "MIDDLE_COLUMN",
                    PayoutMultiplier = 3
                });
            }

            if(IsBottomColumn(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "BOTTOM_COLUMN",
                    PayoutMultiplier = 3
                });
            }

            if(IsFirstDozen(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "FIRST_DOZEN",
                    PayoutMultiplier = 3
                });
            }

            if (IsSecondDozen(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "SECOND_DOZEN",
                    PayoutMultiplier = 3
                });
            }

            if (IsThirdDozen(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "THIRD_DOZEN",
                    PayoutMultiplier = 3
                });
            }

            if (IsRed(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "RED",
                    PayoutMultiplier = 2
                });
            }
            else if (result != 0 && result != 37)
            {
                classifications.Add(new Classification()
                {
                    Name = "BLACK",
                    PayoutMultiplier = 2
                });
            }

            if(IsHigh(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "HIGH",
                    PayoutMultiplier = 2
                });
            }
            else if(IsLow(result))
            {
                classifications.Add(new Classification()
                {
                    Name = "LOW",
                    PayoutMultiplier = 2
                });
            }

            if(result > 0 && result < 37)
            {
                if(IsEven(result))
                {
                    classifications.Add(new Classification()
                    {
                        Name = "EVEN",
                        PayoutMultiplier = 2
                    });
                }
                else
                {
                    classifications.Add(new Classification()
                    {
                        Name = "ODD",
                        PayoutMultiplier = 2
                    });
                }

                if(result < 34)
                {
                    classifications.Add(new Classification()
                    {
                        Name = $"SPLIT_{result}_{result + 3}",
                        PayoutMultiplier = 18
                    });
                }

                if(result > 3)
                {
                    classifications.Add(new Classification()
                    {
                        Name = $"SPLIT_{result - 3}_{result}",
                        PayoutMultiplier = 18
                    });
                }

                if(IsTopColumn(result) || IsMiddleColumn(result))
                {
                    classifications.Add(new Classification()
                    {
                        Name = $"SPLIT_{result}_{result - 1}",
                        PayoutMultiplier = 18
                    });
                }

                if (IsMiddleColumn(result) || IsBottomColumn(result))
                {
                    classifications.Add(new Classification()
                    {
                        Name = $"SPLIT_{result + 1}_{result}",
                        PayoutMultiplier = 18
                    });
                }

                classifications.AddRange(GetStreets(result));
            }

            return classifications;
        }

        private List<Classification> GetStreets(int result)
        {
            var classifications = new List<Classification>();

            int row = (int)Math.Ceiling((double)result / (double)3);

            switch(row)
            {
                case 1:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_1_4"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_1"));
                        break;
                    }
                case 2:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_1_4"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_4_7"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_4"));
                        break;
                    }
                case 3:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_4_7"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_7_10"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_7"));
                        break;
                    }
                case 4:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_7_10"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_10_13"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_10"));
                        break;
                    }
                case 5:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_10_13"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_13_16"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_13"));
                        break;
                    }
                case 6:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_13_16"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_16_19"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_16"));
                        break;
                    }
                case 7:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_16_19"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_19_22"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_19"));
                        break;
                    }
                case 8:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_19_22"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_22_25"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_22"));
                        break;
                    }
                case 9:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_22_25"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_25_28"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_25"));
                        break;
                    }
                case 10:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_25_28"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_28_31"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_28"));
                        break;
                    }
                case 11:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_28_31"));
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_31_34"));
                        classifications.Add(_nameClassifier.GetClassificationByName("STREET_31"));
                        break;
                    }
                case 12:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("DOUBLE_STREET_31_34"));
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException("Invalid Double Street Number");
                    }
            }

            return classifications;
        }

        private bool IsTopColumn(int result)
        {
            return result != 0 && (result % 3 == 0);
        }

        private bool IsMiddleColumn(int result)
        {
            if(result == 2 ||
               result == 5 ||
               result == 8 ||
               result == 11 ||
               result == 14 ||
               result == 17 ||
               result == 20 ||
               result == 23 ||
               result == 26 ||
               result == 29 ||
               result == 32 ||
               result == 35)
            {
                return true;
            }

            return false;
        }

        private bool IsBottomColumn(int result)
        {
            if (result == 1 ||
               result == 4 ||
               result == 7 ||
               result == 10 ||
               result == 13 ||
               result == 16 ||
               result == 19 ||
               result == 22 ||
               result == 25 ||
               result == 28 ||
               result == 31 ||
               result == 34)
            {
                return true;
            }

            return false;
        }

        private bool IsRed(int result)
        {
            if (result == 1 ||
               result == 3 ||
               result == 5 ||
               result == 7 ||
               result == 9 ||
               result == 12 ||
               result == 14 ||
               result == 16 ||
               result == 18 ||
               result == 19 ||
               result == 21 ||
               result == 23 ||
               result == 25 ||
               result == 27 ||
               result == 30 ||
               result == 32 ||
               result == 34 ||
               result == 36)
            {
                return true;
            }

            return false;
        }

        private bool IsFirstDozen(int result)
        {
            return 0 < result && result < 13;
        }

        private bool IsSecondDozen(int result)
        {
            return 12 < result && result < 25;
        }

        private bool IsThirdDozen(int result)
        {
            return 24 < result && result < 37;
        }

        private bool IsHigh(int result)
        {
            return 18 < result && result < 37;
        }

        private bool IsLow(int result)
        {
            return 0 < result && result < 19;
        }

        private bool IsEven(int result)
        {
            return result % 2 == 0;
        }

        private List<Classification> GetCorners(int result)
        {
            var classifications = new List<Classification>();

            switch(result)
            {
                case 0:
                case 37:
                    {
                        break;
                    }
                case 1:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_2_5_1_4"));

                        break;
                    }
                case 2:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_3_6_2_5"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_2_5_1_4"));

                        break;
                    }
                case 3:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_3_6_2_5"));

                        break;
                    }
                case 4:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_2_5_1_4"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_5_8_4_7"));

                        break;
                    }
                case 5:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_3_6_2_5"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_2_5_1_4"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_6_9_5_8"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_5_8_4_7"));

                        break;
                    }
                case 6:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_3_6_2_5"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_6_9_5_8"));

                        break;
                    }
                case 7:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_5_8_4_7"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_8_11_7_10"));

                        break;
                    }
                case 8:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_6_9_5_8"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_5_8_4_7"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_9_12_8_11"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_8_11_7_10"));

                        break;
                    }
                case 9:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_6_9_5_8"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_9_12_8_11"));

                        break;
                    }
                case 10:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_8_11_7_10"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_11_14_10_13"));

                        break;
                    }
                case 11:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_9_12_8_11"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_8_11_7_10"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_12_15_11_14"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_11_14_10_13"));

                        break;
                    }
                case 12:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_9_12_8_11"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_12_15_11_14"));

                        break;
                    }
                case 13:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_11_14_10_13"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_14_17_13_16"));

                        break;
                    }
                case 14:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_12_15_11_14"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_11_14_10_13"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_15_18_14_17"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_14_17_13_16"));

                        break;
                    }
                case 15:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_12_15_11_14"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_15_18_14_17"));

                        break;
                    }
                case 16:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_14_17_13_16"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_17_20_16_19"));

                        break;
                    }
                case 17:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_15_18_14_17"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_14_17_13_16"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_18_21_17_20"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_17_20_16_19"));

                        break;
                    }
                case 18:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_15_18_14_17"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_18_21_17_20"));

                        break;
                    }
                case 19:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_17_20_16_19"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_20_23_19_22"));

                        break;
                    }
                case 20:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_18_21_17_20"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_17_20_16_19"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_21_24_20_23"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_20_23_19_22"));

                        break;
                    }
                case 21:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_18_21_17_20"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_21_24_20_23"));

                        break;
                    }
                case 22:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_20_23_19_22"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_23_26_22_25"));

                        break;
                    }
                case 23:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_21_24_20_23"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_20_23_19_22"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_24_27_23_26"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_23_26_22_25"));

                        break;
                    }
                case 24:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_21_24_20_23"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_24_27_23_26"));

                        break;
                    }
                case 25:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_23_26_22_25"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_26_29_25_28"));

                        break;
                    }
                case 26:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_24_27_23_26"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_23_26_22_25"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_27_30_26_29"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_26_29_25_28"));

                        break;
                    }
                case 27:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_24_27_23_26"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_27_30_26_29"));

                        break;
                    }
                case 28:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_26_29_25_28"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_29_32_28_31"));

                        break;
                    }
                case 29:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_27_30_26_29"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_26_29_25_28"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_30_33_29_32"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_29_32_28_31"));

                        break;
                    }
                case 30:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_27_30_26_29"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_30_33_29_32"));

                        break;
                    }
                case 31:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_29_32_28_31"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_32_35_31_34"));

                        break;
                    }
                case 32:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_30_33_29_32"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_29_32_28_31"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_33_36_32_35"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_32_35_31_34"));

                        break;
                    }
                case 33:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_30_33_29_32"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_33_36_32_35"));

                        break;
                    }
                case 34:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_32_35_31_34"));

                        break;
                    }
                case 35:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_33_36_32_35"));
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_32_35_31_34"));

                        break;
                    }
                case 36:
                    {
                        classifications.Add(_nameClassifier.GetClassificationByName("CORNER_33_36_32_35"));

                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("Invalid result given");
                    }
            }

            return classifications;
        }
    }
}

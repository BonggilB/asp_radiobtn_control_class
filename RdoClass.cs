
        public class RdoClass
        {
            #region 상수

            const int RadioCount = 3; //그룹별 존재하는 라디오 갯수

            #endregion

            #region 변수

            public RadioButton[] RdoBtns { get; set; } = new RadioButton[RadioCount];
            //public RadioButton YesButton { get; set; }
            //public RadioButton NoButton { get; set; }
            public string GroupName { get; set; }
            public Label Lbl { get; set; }

            #endregion
            public RdoClass[] GetRadioBtn(Control Controls)
            {
                List<List<RadioButton>> radioButtonGroups = new List<List<RadioButton>>();
                //aspx에 존재하는 모든 라디오버튼 가져와서
                FindAllRadioButtons(ref radioButtonGroups, Controls);

                RdoClass[] rdoClasses = new RdoClass[radioButtonGroups.Count];

                int a = 0;
                //그룹별로
                foreach (List<RadioButton> group in radioButtonGroups)
                {
                    rdoClasses[a] = new RdoClass();
                    rdoClasses[a].GroupName = group[0].GroupName;
                    int b = 0;

                    foreach (RadioButton radioButton in group)
                    {
                        RdoBtns[b] = radioButton;
                        b++;
                    }
                    a++;
                }

                return rdoClasses;
            }
            //문서별 Extension 해서 기능추가 예정

            void FindAllRadioButtons(ref List<List<RadioButton>> radioButtonGroups, Control control)
            {
                foreach (Control childControl in control.Controls)
                {
                    if (childControl is RadioButton radioButton)
                    {
                        bool groupExists = false;
                        //라디오 버튼이라면 Groupname별로 리스트에 저장
                        foreach (List<RadioButton> group in radioButtonGroups)
                        {
                            if (group[0].GroupName == radioButton.GroupName)
                            {
                                group.Add(radioButton);
                                groupExists = true;
                                break;
                            }
                        }
                        if (!groupExists)
                        {
                            List<RadioButton> newGroup = new List<RadioButton>();
                            newGroup.Add(radioButton);
                            radioButtonGroups.Add(newGroup);
                        }
                    }
                    else
                    {
                        FindAllRadioButtons(ref radioButtonGroups, childControl);
                    }
                }
            }
        }

        public class Extensions : RdoClass
        {
            public void SetRdobtn(Control Controls, DataSet ds)
            {
                RdoClass[] rdoClasses = GetRadioBtn(Controls);
                int i = 6;// 데이터 셋의 라디오 버튼 상태 컬럼이 6번째부터 2개씩 증가돼 저장돼있음

                foreach (RdoClass rdoClass in rdoClasses)
                {
                    //if (ds.Tables[0].Rows[0].ItemArray[i].ToString() == "O")
                    //    rdoClass.YesButton.Checked = true;
                    //else if (ds.Tables[0].Rows[0].ItemArray[i].ToString() == "X")
                    //    rdoClass.NoButton.Checked = true;
                    //i += 2;

                    //rdoClass.YesButton.Visible = false;
                    //rdoClass.NoButton.Visible = false
                }
            }

            public void SetRdobtn(Control Controls, bool Visible)
            {
                RdoClass[] rdoClasses = GetRadioBtn(Controls);

                foreach (RdoClass rdoClass in rdoClasses)
                {
                    foreach (RadioButton rdobtn in RdoBtns)
                        rdobtn.Visible = Visible;
                }
            }

            //public string GetSelectedValue(RdoClass rdoClass)
            //{
            //    for (int i = 0; i < RdoBtns.Length; i++)
            //    {
            //        if(RdoBtns[i].Checked && i == 0)

            //    }
            //        rdobtn.
            //    if (rdoClass.YesButton.Checked)
            //        return "O";
            //    else
            //        return "X";
            //}
        }

using System.Diagnostics;

namespace ProjectCMD
{
    public partial class Form1 : Form
    {
        private string currentItemName;
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private async void button1_Click(object sender, EventArgs e) // 버튼 클릭 시 작동
        {
            string Rag = "reg";
            progressBar1.Value = 0; // 프로세스 0으로 설정
            progressBar1.Maximum = checkedListBox1.CheckedItems.Count; // 체크 된 박스만큼 최대값 설정

            var commands = new List<string[]> // 체크박스마다 명령어 여러 줄 실행(배열 함수)
        {
            new string[]
            {
                "sc stop sysmain",
                "sc config sysmain start=disabled",
                "sc stop diagtrack",
                "sc config diagtrack start=disabled",
                "sc stop wsearch",
                "sc config wsearch start=disabled",
                "sc stop rasman",
                "sc config rasman start=disabled",
                "sc stop sstpsvc",
                "sc config sstpsvc start=demand"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Control\\Power\" /v \"CsEnabled\" /t reg_dword /d 0 /f",
                "powercfg -restoredefaultschemes",
                "powercfg -h off",
                "powercfg /s 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c",
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Power\\PowerSettings\\54533251-82be-4824-96c1-47b60b740d00\\be337238-0d82-4146-a960-4f3749d470c7\" /v \"Attributes\" /t reg_dword /d 2 /f",
                "POWERCFG /SETACVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 0012ee47-9041-4b5d-9b77-535fba8b1442 6738e2c4-e8a5-4a42-b16a-e040e769756e 0",
                "POWERCFG /SETDCVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 0012ee47-9041-4b5d-9b77-535fba8b1442 6738e2c4-e8a5-4a42-b16a-e040e769756e 0",
                "POWERCFG /SETACVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 94d3a615-a899-4ac5-ae2b-e4d8f634367f 1",
                "POWERCFG /SETDCVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 94d3a615-a899-4ac5-ae2b-e4d8f634367f 0",
                "POWERCFG /SETACVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 893dee8e-2bef-41e0-89c6-b55d0929964c 100",
                "POWERCFG /SETDCVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 893dee8e-2bef-41e0-89c6-b55d0929964c 99",
                "POWERCFG /SETACVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 bc5038f7-23e0-4960-96da-33abaf5935ec 100",
                "POWERCFG /SETDCVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 bc5038f7-23e0-4960-96da-33abaf5935ec 100",
                "POWERCFG /SETACVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 be337238-0d82-4146-a960-4f3749d470c7 4",
                "POWERCFG /SETDCVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 54533251-82be-4824-96c1-47b60b740d00 be337238-0d82-4146-a960-4f3749d470c7 4",
                "POWERCFG /SETACVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0",
                "POWERCFG /SETDCVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0",
                "POWERCFG /SETACVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 0",
                "POWERCFG /SETDCVALUEINDEX 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 0"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Power\\PowerSettings\\54533251-82be-4824-96c1-47b60b740d00\\0cc5b647-c1df-4637-891a-dec35c318583\" /v \"ValueMax\" /t reg_dword /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Ndu\" /v \"Start\" /t reg_dword /d 4 /f",
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\Ndu\" /v \"Start\" /t reg_dword /d 4 /f",
                "bcdedit /set removememory 0"
            },
            new string[]
            {
                "netsh interface tcp set global autotuninglevel=highlyrestricted",
                "netsh int tcp show global"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search\" /v \"AllowCortana\" /t reg_dword /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_CURRENT_USER\\System\\GameConfigStore\" /v \"GameDVR_Enabled\" /t reg_dword /d 1 /f",
                "reg add \"HKEY_CURRENT_USER\\System\\GameConfigStore\" /v \"GameDVR_EFSEFeatureFlags\" /t reg_dword /d 0 /f",
                "reg add \"HKEY_CURRENT_USER\\System\\GameConfigStore\" /v \"GameDVR_HonorUserFSEBehaviorMode\" /t reg_dword /d 0 /f",
                "reg add \"HKEY_CURRENT_USER\\System\\GameConfigStore\" /v \"GameDVR_DXGIHonorFSEWindowsCompatible\" /t reg_dword /d 0 /f",
                "reg add \"HKEY_CURRENT_USER\\System\\GameConfigStore\" /v \"GameDVR_FSEBehaviorMode\" /t reg_dword /d 0 /f",
                "reg add \"HKEY_CURRENT_USER\\System\\GameConfigStore\" /v \"GameDVR_FSEBehavior\" /t reg_dword /d 2 /f",
                "reg add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR\" /v \"EchoCancellationEnabled\" /t reg_dword /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications\" /v \"GlobalUserDisabled\" /t REG_DWORD /d 1 /f",
                "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Search\" /v \"BackgroundAppGlobalToggle\" /t REG_DWORD /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\" /v \"Allowtelemetry\" /t REG_DWORD /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config\" /v \"DODownloadMode\" /t REG_DWORD /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers\" /v \"HwSchMode\" /t REG_DWORD /d 1 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Scan\" /v \"AvgCPULoadFactor\" /t REG_DWORD /d 10 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\" /v \"NetworkThrottlingIndex\" /t reg_dword /d 4294967295 /f",
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\" /v \"SystemResponsiveness\" /t reg_dword /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games\" /v \"GPU Priority\" /t reg_dword /d 8 /f",
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games\" /v \"Priority\" /t reg_dword /d 6 /f",
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games\" /v \"Scheduling Category\" /t reg_sz /d High /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces\" /v \"TcpAckFrequency\" /t reg_dword /d 1 /f",
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces\" /v \"TCPNoDelay\" /t reg_dword /d 1 /f"
            },
            new string[]
            {
                "bcdedit /set useplatformclock false",
                "bcdedit /set disabledynamictick yes",
                "bcdedit /deletevalue useplatformclock"
            },
            new string[]
            {
                "ipconfig /flushdns"
            },
            new string[]
            {
                "del /q/f/s %TEMP%\\*",
                "del /q/f/s C:\\Windows\\Temp\\*",
                "del /q/f/s C:\\Temp\\*"
            },
            new string[]
            {
                "reg add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar\" /v \"AutoGameModeEnabled\" /t reg_dword /d 0 /f",
                "reg add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar\" /v \"AllowAutoGameMode\" /t reg_dword /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Power\\PowerThrottling\" /v \"PowerThrottlingOff\" /t reg_dword /d 1 /f"
            },
            new string[]
            {
                "fsutil behavior set DisableDeleteNotify 1"
            },
            new string[]
            {
                "DISM.exe /Online /Set-ReservedStorageState /State:Disabled"
            },
            new string[]
            {
                "reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\FTH\" /v \"Enabled\" /t reg_dword /d 0 /f"
            },
            new string[]
            {
                "reg add \"HKEY_USERS\\.DEFAULT\\Control Panel\\KeyBoard\" /v \"InitialKeyboardIndicators\" /t reg_sz /d 2 /f"
            },
            new string[]
            {
                "ipconfig /flushdns"
            },
            new string[]
            {
                "sfc /scannow"
            },
            new string[]
            {
                "net stop wuauserv",
                "net stop cryptSvc",
                "net stop bits",
                "net stop msiserver",
                "Ren C:\\Windows\\SoftwareDistribution SoftwareDistribution.old",
                "Ren C:\\Windows\\System32\\catroot2 Catroot2.old",
                "net start wuauserv",
                "net start cryptSvc",
                "net start bits",
                "net start msiserver",
                "\"%ProgramFiles%\\Windows Defender\\MPCMDRUN.exe\" -RemoveDefinitions -All",
                "\"%ProgramFiles%\\Windows Defender\\MPCMDRUN.exe\" -SignatureUpdate"
            },
            new string[]
            {
                "Dism /online /cleanup-image /scanhealth",
                "Dism /online /cleanup-image /checkhealth",
                "Dism /online /cleanup-image /restorehealth"
            }
        };

            foreach (object item in checkedListBox1.CheckedItems) // 순차적으로 체크 된 체크리스트 실행
            {
                int index = checkedListBox1.Items.IndexOf(item); // 체크리스트의 배열 index값 불러오기

                if (index >= 0 && index < commands.Count)
                {
                    string itemName = item.ToString();
                    label1.Text = ($"{itemName} 작업 중");


                    foreach (string command in commands[index])
                    {
                        currentItemName = itemName;
                        ExecuteCommand($"/c {command}"); // 명령어 실행
                        // CMD 창 유지 해야할 시 "/c"를 "/k로 바꿔준다. $"/k {command}"
                    }

                    label1.Text = ($"{itemName} 작업 완료");
                    progressBar1.Value++;
                }
            }

            MessageBox.Show("모든 작업이 완료되었습니다");

            Form2 changeform2 = new Form2();
            changeform2.Show();
            this.Hide();
        }
        private void ExecuteCommand(string args)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", args)
            {
                UseShellExecute = false, // 창을 새로 만들지 않음
                CreateNoWindow = false,   // 콘솔 창 숨기기 // = true == 창 숨기기
                Verb = "runas"           // 관리자 권한으로 실행
            };

            using (Process process = Process.Start(processInfo))
            {
                process.WaitForExit(); // 명령어 실행이 끝날 때까지 대기
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                bool allChecked = true;

                // 체크리스트 항목의 체크 상태 확인
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (!checkedListBox1.GetItemChecked(i))
                    {
                        allChecked = false;
                        break;
                    }
                }

                // 모든 항목이 체크되었으면 전체 체크박스 체크
                checkBox1.Checked = allChecked;
            });
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form0 changeform0 = new Form0();
            changeform0.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

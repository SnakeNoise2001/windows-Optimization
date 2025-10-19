namespace ProjectCMD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            checkedListBox1 = new CheckedListBox();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            label1 = new Label();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.ColumnWidth = 250;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "불필요 서비스 종료", "전원옵션 설정", "CPU 언파킹 설정", "메모리 최적화", "인터넷 최적화", "코타나 끄기", "게임바 최적화", "백그라운드 앱 최적화", "데이터 최적화", "데이터 전송 끄기", "GPU 스케줄러 끄기", "윈도우 디펜더 CPU 사용량 제한", "인터넷 속도 제한 해체", "레지스트리 그래픽 설정", "패스트 핑", "CPU 고정 타이머 해체", "인터넷 캐시 삭제", "임시파일 삭제", "게임모드 끄기", "쓰로들링 방지", "SSD 모든공간 사용", "저장장치 절전모드 해체", "FTH 끄기", "부팅 시 넘버락 ON", "인터넷 캐시 삭제", "윈도우 시스템 파일 복구", "윈도우 업데이트 오류 해결", "윈도우 복구 프로그램 실행" });
            checkedListBox1.Location = new Point(12, 123);
            checkedListBox1.MultiColumn = true;
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(760, 202);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 331);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(760, 20);
            progressBar1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(616, 426);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "적용";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 354);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 98);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(112, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "전체 선택 / 해체";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Click += checkBox1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo1;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(760, 80);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(535, 426);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "<< 이전";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(697, 426);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 7;
            button3.Text = "닫기";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(checkedListBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FBS";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private ProgressBar progressBar1;
        private Button button1;
        private Label label1;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button3;
    }
}

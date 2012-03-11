<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NumericUpDown制限時間 = New System.Windows.Forms.NumericUpDown()
        Me.Label制限時間 = New System.Windows.Forms.Label()
        Me.RadioButtonGC = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonOP = New System.Windows.Forms.RadioButton()
        Me.RadioButtonFF = New System.Windows.Forms.RadioButton()
        Me.RadioButtonIE = New System.Windows.Forms.RadioButton()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Buttonキャンセル = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown待ち時間 = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxSound = New System.Windows.Forms.CheckBox()
        Me.RadioButtonSF = New System.Windows.Forms.RadioButton()
        CType(Me.NumericUpDown制限時間, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown待ち時間, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericUpDown制限時間
        '
        Me.NumericUpDown制限時間.Location = New System.Drawing.Point(87, 150)
        Me.NumericUpDown制限時間.Name = "NumericUpDown制限時間"
        Me.NumericUpDown制限時間.Size = New System.Drawing.Size(51, 19)
        Me.NumericUpDown制限時間.TabIndex = 4
        Me.NumericUpDown制限時間.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label制限時間
        '
        Me.Label制限時間.AutoSize = True
        Me.Label制限時間.Location = New System.Drawing.Point(10, 152)
        Me.Label制限時間.Name = "Label制限時間"
        Me.Label制限時間.Size = New System.Drawing.Size(73, 12)
        Me.Label制限時間.TabIndex = 1
        Me.Label制限時間.Text = "制限時間(分)"
        '
        'RadioButtonGC
        '
        Me.RadioButtonGC.AutoSize = True
        Me.RadioButtonGC.Location = New System.Drawing.Point(7, 63)
        Me.RadioButtonGC.Name = "RadioButtonGC"
        Me.RadioButtonGC.Size = New System.Drawing.Size(101, 16)
        Me.RadioButtonGC.TabIndex = 2
        Me.RadioButtonGC.Text = "Google Chrome"
        Me.RadioButtonGC.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButtonSF)
        Me.GroupBox1.Controls.Add(Me.RadioButtonOP)
        Me.GroupBox1.Controls.Add(Me.RadioButtonFF)
        Me.GroupBox1.Controls.Add(Me.RadioButtonIE)
        Me.GroupBox1.Controls.Add(Me.RadioButtonGC)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 132)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "起動するブラウザ"
        '
        'RadioButtonOP
        '
        Me.RadioButtonOP.AutoSize = True
        Me.RadioButtonOP.Location = New System.Drawing.Point(6, 85)
        Me.RadioButtonOP.Name = "RadioButtonOP"
        Me.RadioButtonOP.Size = New System.Drawing.Size(53, 16)
        Me.RadioButtonOP.TabIndex = 7
        Me.RadioButtonOP.Text = "Opera"
        Me.RadioButtonOP.UseVisualStyleBackColor = True
        '
        'RadioButtonFF
        '
        Me.RadioButtonFF.AutoSize = True
        Me.RadioButtonFF.Location = New System.Drawing.Point(7, 41)
        Me.RadioButtonFF.Name = "RadioButtonFF"
        Me.RadioButtonFF.Size = New System.Drawing.Size(98, 16)
        Me.RadioButtonFF.TabIndex = 3
        Me.RadioButtonFF.Text = "Mozilla Firefox"
        Me.RadioButtonFF.UseVisualStyleBackColor = True
        '
        'RadioButtonIE
        '
        Me.RadioButtonIE.AutoSize = True
        Me.RadioButtonIE.Checked = True
        Me.RadioButtonIE.Location = New System.Drawing.Point(7, 18)
        Me.RadioButtonIE.Name = "RadioButtonIE"
        Me.RadioButtonIE.Size = New System.Drawing.Size(108, 16)
        Me.RadioButtonIE.TabIndex = 6
        Me.RadioButtonIE.TabStop = True
        Me.RadioButtonIE.Text = "Internet Explorer"
        Me.RadioButtonIE.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(5, 230)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 7
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'Buttonキャンセル
        '
        Me.Buttonキャンセル.Location = New System.Drawing.Point(86, 230)
        Me.Buttonキャンセル.Name = "Buttonキャンセル"
        Me.Buttonキャンセル.Size = New System.Drawing.Size(75, 23)
        Me.Buttonキャンセル.TabIndex = 8
        Me.Buttonキャンセル.Text = "キャンセル"
        Me.Buttonキャンセル.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "待ち時間(分)"
        '
        'NumericUpDown待ち時間
        '
        Me.NumericUpDown待ち時間.Location = New System.Drawing.Point(87, 177)
        Me.NumericUpDown待ち時間.Name = "NumericUpDown待ち時間"
        Me.NumericUpDown待ち時間.Size = New System.Drawing.Size(51, 19)
        Me.NumericUpDown待ち時間.TabIndex = 5
        Me.NumericUpDown待ち時間.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'CheckBoxSound
        '
        Me.CheckBoxSound.AutoSize = True
        Me.CheckBoxSound.Location = New System.Drawing.Point(12, 202)
        Me.CheckBoxSound.Name = "CheckBoxSound"
        Me.CheckBoxSound.Size = New System.Drawing.Size(150, 16)
        Me.CheckBoxSound.TabIndex = 6
        Me.CheckBoxSound.Text = "起動・終了時に音を鳴らす"
        Me.CheckBoxSound.UseVisualStyleBackColor = True
        '
        'RadioButtonSF
        '
        Me.RadioButtonSF.AutoSize = True
        Me.RadioButtonSF.Location = New System.Drawing.Point(6, 107)
        Me.RadioButtonSF.Name = "RadioButtonSF"
        Me.RadioButtonSF.Size = New System.Drawing.Size(53, 16)
        Me.RadioButtonSF.TabIndex = 8
        Me.RadioButtonSF.Text = "Safari"
        Me.RadioButtonSF.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(221, 267)
        Me.Controls.Add(Me.CheckBoxSound)
        Me.Controls.Add(Me.NumericUpDown待ち時間)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Buttonキャンセル)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label制限時間)
        Me.Controls.Add(Me.NumericUpDown制限時間)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "温泉旅館TV設定"
        CType(Me.NumericUpDown制限時間, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown待ち時間, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumericUpDown制限時間 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label制限時間 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonGC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonIE As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonFF As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents Buttonキャンセル As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown待ち時間 As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBoxSound As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButtonOP As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonSF As System.Windows.Forms.RadioButton

End Class

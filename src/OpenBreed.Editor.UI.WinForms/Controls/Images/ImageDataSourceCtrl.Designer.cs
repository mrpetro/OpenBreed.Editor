﻿namespace OpenBreed.Editor.UI.WinForms.Controls.Images
{
    partial class ImageDataSourceCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpAssetEntryRef = new System.Windows.Forms.GroupBox();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.AssetEntryRef = new OpenBreed.Editor.UI.WinForms.Controls.Common.EntryRefCtrl();
            this.grpAssetEntryRef.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAssetEntryRef
            // 
            this.grpAssetEntryRef.Controls.Add(this.AssetEntryRef);
            this.grpAssetEntryRef.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAssetEntryRef.Location = new System.Drawing.Point(0, 0);
            this.grpAssetEntryRef.Name = "grpAssetEntryRef";
            this.grpAssetEntryRef.Size = new System.Drawing.Size(533, 43);
            this.grpAssetEntryRef.TabIndex = 1;
            this.grpAssetEntryRef.TabStop = false;
            this.grpAssetEntryRef.Text = "Asset entry id";
            // 
            // grpFormat
            // 
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFormat.Location = new System.Drawing.Point(0, 43);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(533, 195);
            this.grpFormat.TabIndex = 2;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Format";
            // 
            // AssetEntryRef
            // 
            this.AssetEntryRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetEntryRef.Location = new System.Drawing.Point(3, 16);
            this.AssetEntryRef.Name = "AssetEntryRef";
            this.AssetEntryRef.Size = new System.Drawing.Size(527, 24);
            this.AssetEntryRef.TabIndex = 0;
            // 
            // DbEntryAssetRefCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpFormat);
            this.Controls.Add(this.grpAssetEntryRef);
            this.Name = "DbEntryAssetRefCtrl";
            this.Size = new System.Drawing.Size(533, 238);
            this.grpAssetEntryRef.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.EntryRefCtrl AssetEntryRef;
        private System.Windows.Forms.GroupBox grpAssetEntryRef;
        private System.Windows.Forms.GroupBox grpFormat;
    }
}
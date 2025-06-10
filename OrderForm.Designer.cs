namespace ресторан_проект
{
    partial class OrderForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            listBoxOrders = new ListBox();
            buttonAddOrder = new Button();
            buttonSearchOrder = new Button();
            buttonDeleteOrder = new Button();
            SuspendLayout();
            // 
            // listBoxOrders
            // 
            listBoxOrders.Anchor = AnchorStyles.None;
            listBoxOrders.FormattingEnabled = true;
            listBoxOrders.Location = new Point(49, 56);
            listBoxOrders.Name = "listBoxOrders";
            listBoxOrders.Size = new Size(656, 104);
            listBoxOrders.TabIndex = 0;
            // 
            // buttonAddOrder
            // 
            buttonAddOrder.Anchor = AnchorStyles.None;
            buttonAddOrder.Location = new Point(49, 193);
            buttonAddOrder.Name = "buttonAddOrder";
            buttonAddOrder.Size = new Size(150, 29);
            buttonAddOrder.TabIndex = 1;
            buttonAddOrder.Text = "добавить заказ";
            buttonAddOrder.UseVisualStyleBackColor = true;
            buttonAddOrder.Click += buttonAddOrder_Click;
            // 
            // buttonSearchOrder
            // 
            buttonSearchOrder.Anchor = AnchorStyles.None;
            buttonSearchOrder.Location = new Point(49, 245);
            buttonSearchOrder.Name = "buttonSearchOrder";
            buttonSearchOrder.Size = new Size(150, 29);
            buttonSearchOrder.TabIndex = 2;
            buttonSearchOrder.Text = "редактировать";
            buttonSearchOrder.UseVisualStyleBackColor = true;
            buttonSearchOrder.Click += button1_Click;
            // 
            // buttonDeleteOrder
            // 
            buttonDeleteOrder.Anchor = AnchorStyles.None;
            buttonDeleteOrder.Location = new Point(49, 297);
            buttonDeleteOrder.Name = "buttonDeleteOrder";
            buttonDeleteOrder.Size = new Size(150, 29);
            buttonDeleteOrder.TabIndex = 3;
            buttonDeleteOrder.Text = "удалить заказ";
            buttonDeleteOrder.UseVisualStyleBackColor = true;
            buttonDeleteOrder.Click += button2_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonDeleteOrder);
            Controls.Add(buttonSearchOrder);
            Controls.Add(buttonAddOrder);
            Controls.Add(listBoxOrders);
            Name = "OrderForm";
            Text = "Form1";
            Load += OrderForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxOrders;
        private Button buttonAddOrder;
        private Button button1;
        private Button button2;
        private Button buttonSearchOrder;
        private Button buttonDeleteOrder;
    }
}
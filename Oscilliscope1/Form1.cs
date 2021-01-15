using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using NationalInstruments;
using System.IO;

namespace Oscilliscope1
{
    public partial class Oscilloscope : Form
    {
        // creating the asynchronous call back, the analog input task, and the reader.
        //public AsyncCallback inputRead;
        private NationalInstruments.DAQmx.Task analogInTask;

        //public NationalInstruments.DAQmx.Task runningTask = new NationalInstruments.DAQmx.Task();
        // create the channel reader.
        public NationalInstruments.DAQmx.AnalogMultiChannelReader reader;

        public bool appendFlag = false;
        public int lowChan;
        public int highChan;
        public int samplesPChannel;
        public double sampleRate;
        public double voltRangeHigh;
        public double voltRangeLow;
        public int size;
        public List<string> chanNameStringArray = new List<string>();
        public double[,] voltageArray;
        public double[,] transpose;

        public bool dataFlag;

        public double[,] data;
        public double[] time;

        public Oscilloscope()
        {
            InitializeComponent();            
        }

        private void Oscilloscope_Load(object sender, EventArgs e)
        {
            stop.Text = "Exit";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(samplesPerChannel.Value / 10);
            if (value > Convert.ToDouble(10 * rate.Value))
            {
                samplesPerChannel.Value = 10000;
                rate.Value = 1000;
            }
            else
            {
                // do nthing
            }
            
        }

        private void stop_Click(object sender, EventArgs e)
        {
            // turn all inputs back on or to enabled.
            collectButton.Enabled = true;
            deviceName.Enabled = true;
            highChannel.Enabled = true;
            lowChannel.Enabled = true;
            terminalConfig.Enabled = true;
            voltageRange.Enabled = true;
            samplesPerChannel.Enabled = true;
            rate.Enabled = true;
            collectButton.Enabled = true;
            dataFlag = false;
            Application.Exit(); // exit the program
        }

        private void collectButton_Click(object sender, EventArgs e)
        {
            // set dataFlag true

            dataFlag = true;

            analogInTask = new NationalInstruments.DAQmx.Task();

            collectButton.Enabled = false;
            deviceName.Enabled = false;
            highChannel.Enabled = false;
            lowChannel.Enabled = false;
            terminalConfig.Enabled = false;
            voltageRange.Enabled = false;
            samplesPerChannel.Enabled = false;
            rate.Enabled = false;
            this.chart1.Series.Clear();

            try
            {
                // grabing the values from the UI front panel 
                sampleRate = Convert.ToDouble(rate.Value);
                samplesPChannel = Convert.ToInt32(samplesPerChannel.Value);
                lowChan = Convert.ToInt32(lowChannel.Value);
                highChan = Convert.ToInt32(highChannel.Value);

                string deviceNamed = deviceName.Text;
                string termConfig = terminalConfig.Text;

                #region voltage range selector
                if (voltageRange.SelectedIndex == 0)
                {
                    voltRangeHigh = 10;
                    voltRangeLow = -10;
                }
                else if (voltageRange.SelectedIndex == 1)
                {
                    voltRangeHigh = 5;
                    voltRangeLow = -5;
                }
                else if (voltageRange.SelectedIndex == 2)
                {
                    voltRangeHigh = 1;
                    voltRangeLow = -1;
                }
                else
                {
                    voltRangeHigh = 0.2;
                    voltRangeLow = -0.2;
                }
                #endregion

                // combining string for dev name and input ports

                string devAndChannels = deviceNamed + "/" + "ai" + Convert.ToString(lowChan) + ":" + Convert.ToString(highChan);

                #region channel creation and config & reader creation / config
                analogInTask.AIChannels.CreateVoltageChannel(devAndChannels, "", (NationalInstruments.DAQmx.AITerminalConfiguration)(-1), voltRangeLow, voltRangeHigh,
                  NationalInstruments.DAQmx.AIVoltageUnits.Volts);
                
                analogInTask.Timing.ConfigureSampleClock("",sampleRate,NationalInstruments.DAQmx.SampleClockActiveEdge.Rising,NationalInstruments.DAQmx.SampleQuantityMode.FiniteSamples, samplesPChannel);

                analogInTask.Control(NationalInstruments.DAQmx.TaskAction.Verify);

                start_Task();
                analogInTask.Start();

                //inputCallBack = inputRead;
                reader = new NationalInstruments.DAQmx.AnalogMultiChannelReader(analogInTask.Stream);
                
                reader.SynchronizeCallbacks = true;

                // Set up next callback
                //IAsyncResult asyncResult = reader.BeginReadMultiSample(samplesPChannel, inputRead, reader);
                
                reader.BeginReadMultiSample(samplesPChannel, inputRead, reader);
                #endregion

            }
            catch(NationalInstruments.DAQmx.DaqException exception)
            {
                end_Task();
                MessageBox.Show(exception.Message);
            }
            
         }

        private void inputRead(IAsyncResult asyncResult)
        {
                // creating an array.
                
            double time2 = 0;
                
             size = (highChan - lowChan) + 1;
            // creating an array to put the data from the reader into.
            voltageArray = new double[size, samplesPChannel];
            transpose = new double[samplesPChannel, size];

            double timeIncrement;

            // time increment
            if(lowChan ==  0)
            {
                 timeIncrement = Convert.ToDouble((highChan +1) / sampleRate);
            }
            else if(lowChan == highChan)
            {
                timeIncrement = Convert.ToDouble((1)/ sampleRate);
            }
            else
            {
                timeIncrement = Convert.ToDouble((highChan - lowChan) / sampleRate);
            }          

            // read the data coming in from the NI DAQ board.
            data = reader.EndReadMultiSample(asyncResult);
            time = new double[samplesPChannel];

            //int q = 0;
            int r = 0;
            try
            {
                //if(analogInTask != null && analogInTask == asyncResult.AsyncState)
                //{
                if(lowChan == 0)
                {
                    //filling out the array with the data from the reader.
                    for(int i = lowChan; i <= highChan; i++)
                    {
                        time2 = 0;
                        for (int p = 0; p < samplesPChannel; p++)
                        {
                            voltageArray[i, p] = data[i, p];
                            transpose[p, i] = data[i, p];
                            time[p] = time2;
                            time2 = time2 + timeIncrement;
                            //MessageBox.Show(time2.ToString());
                        }
                    }
                  }
                else if(lowChan == highChan)
                {
                    
                        time2 = 0;
                        for (int p = 0; p < samplesPChannel; p++)
                        {
                            //voltageArray[q, r] = data[q, r];
                            transpose[r, 0] = data[0, p];
                            time[p] = time2;
                            time2 = time2 + timeIncrement;
                            //MessageBox.Show(timeIncrement.ToString());
                        }
                }

                //}

                #region set axis scale
                if (voltageRange.Text == "+/- 10V")
                {
                    chart1.ChartAreas[0].AxisY.Maximum = 10.1;
                    chart1.ChartAreas[0].AxisY.Minimum = -10.1;

                }
                else if(voltageRange.Text == "+/- 5V")
                {
                    chart1.ChartAreas[0].AxisY.Maximum = 5.1;
                    chart1.ChartAreas[0].AxisY.Minimum = -5.1;
                }
                else if(voltageRange.Text == "+/- 1V")
                {
                    chart1.ChartAreas[0].AxisY.Maximum = 1.1;
                    chart1.ChartAreas[0].AxisY.Minimum = -1.1;
                }
                else
                {
                    chart1.ChartAreas[0].AxisY.Maximum = 0.22;
                    chart1.ChartAreas[0].AxisY.Minimum = -0.22;
                }
                #endregion

                for (int i = lowChan; i <= highChan; i++)
                {
                    string chan_name = "Channel" + Convert.ToString(Convert.ToInt32(i));
                    chart1.Series.Add(chan_name);
                    

                    for (int p = 0; p < samplesPChannel -1; p++)
                    {
                        chart1.Series[chan_name].Points.AddXY(time[p], data[i - lowChan, p]);
                        chart1.Series[chan_name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    }
                }
              }
            catch(Exception ex)
            {
                end_Task();
                
                MessageBox.Show(ex.Message);
            }
            end_Task();
            
        }

        private void start_Task()
        {         
                // disabling User Input until data collection is finished.
                collectButton.Enabled = false;
                deviceName.Enabled = false;
                highChannel.Enabled = false;
                lowChannel.Enabled = false;
                terminalConfig.Enabled = false;
                voltageRange.Enabled = false;
                samplesPerChannel.Enabled = false;
                rate.Enabled = false;
            
        }

        private void end_Task()
        {
            // re-enabling user input
            collectButton.Enabled = true;
            deviceName.Enabled = true;
            highChannel.Enabled = true;
            lowChannel.Enabled = true;
            terminalConfig.Enabled = true;
            voltageRange.Enabled = true;
            samplesPerChannel.Enabled = true;
            rate.Enabled = true;

            // stop the tasks
            analogInTask.Stop();
            analogInTask.Dispose();
        }

        #region handles combobox stuff (like letters and stuff)
        private void deviceName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void terminalConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void voltageRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void highChannel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lowChannel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        // makes it so the user cannot put incorrect channel values.
        private void lowChannel_ValueChanged(object sender, EventArgs e)
        {
            if (terminalConfig.Text == "Differential")
            {
                highChannel.Maximum = 7;
            }
            else
            {
                highChannel.Maximum = 15;
            }

            if (lowChannel.Value >= highChannel.Value)
            {
                
                lowChannel.Value = highChannel.Value;
            }
            else 
            {
                
                // do nothing
            }
            int highChanNum = Convert.ToInt32(highChannel.Value + 1);
            rate.Maximum = 500000 / highChanNum;

        }

        private void highChannel_ValueChanged(object sender, EventArgs e)
        {
            // making sure the low channel cannot be higher than the high channel and 
            // that the high channel is not lower than the low channel. 
            // if either is the case then I seperate them by 1 channel.

            if(terminalConfig.Text == "Differential")
            {
                highChannel.Maximum = 7;
            }
           
            if (highChannel.Value < lowChannel.Value)
            {
                highChannel.Value = lowChannel.Value;
            }
            else
            {
                // do nothing
            }

            int highChanNum = Convert.ToInt32(highChannel.Value + 1);
            rate.Maximum = 500000 / highChanNum;

        }

        private void rate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void terminalConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            // want to make sure the user cant select an un reasonable number.
            if (terminalConfig.Text == "Differential")
            {
                highChannel.Maximum = 7;
                if (highChannel.Value > 7)
                {
                    highChannel.Value = 7;
                }
            }
            else
            {
                highChannel.Maximum = 15;
            }
        }

        #endregion

        #region handles file I/O stuff (at least the value_changed stuff)
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you really wish to quit?", "Exit", MessageBoxButtons.OKCancel);
            chart1.Series.Clear();
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            // showing the dialog box for opening a file
            // has a title "Open a File" and directory c:
            // and initial file name blank.

            string path;
           
            // creating the fileOpenDailog titles, intial directory, and filter type.
            fileOpenDlg.Title = "Open A File";
            fileOpenDlg.InitialDirectory = "C:/Users/Ravi-T440/Documents";
            fileOpenDlg.Filter = "CSV|*.csv";

            fileOpenDlg.FileName = "";

            if (fileOpenDlg.ShowDialog() != DialogResult.Cancel)
            {
                // creating a line of text to be read by splitting with comma seperated file type.
                path = fileOpenDlg.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(fileOpenDlg.FileName))
                    {
                        string line = sr.ReadLine();
                        line = sr.ReadLine();                                 //read date
                        line = sr.ReadLine();                                 //read time

                        string[] readString = line.Split(',');

                        // getting the length and width sizes of the array
                        int length = Convert.ToInt32(readString[1]);
                        line = sr.ReadLine();                                //get points / channels
                        readString = line.Split(',');

                        int widthSize = readString.Length;
                           
                        // creating a data array
                        double[,] dataArray = new double[length, widthSize];

                        for (int i = 0; i < length; i++)
                        {
                            line = sr.ReadLine();
                            readString = line.Split(',');
                            for (int j = 1; j < widthSize; j++)
                            {
                                dataArray[i, j] = double.Parse(readString[j]);
                            }
                        }
                        string chan_name = "";

                        //creating channel names
                        for (int i = 0; i < widthSize; i++)
                        {
                            chan_name = "Channel" + Convert.ToString(Convert.ToInt32(i));
                            chart1.Series.Add(chan_name);
                        }
                        // the data plotting loop
                        for (int i = 0; i < length; i++)
                        {
                            for (int p = 1; p < widthSize ; p++)
                            {
                                chart1.Series[p].Points.AddXY(dataArray[i, 0], dataArray[i, p]);
                                chart1.Series[p].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                            }
                        }// closes data plotting loop
                    }//closes using streamreader
                }//closes try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
               
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // creating a string called saveFile to be used to hold the name of the saved file.
            string saveFile = "";

            // setting parameters for the saveFD directory, title, and filename, filter.
            saveFD.InitialDirectory = "C:/Users/Ravi-T440/Documents";
            saveFD.Title = "Save a csv file";
            saveFD.FileName = "";

            saveFD.Filter = "CSV|*.csv";

            chanNameStringArray.Clear();

            if (dataFlag == true)
            {

                // want to append the names of the channels into a string here
                // this will be used later on when saving the data.
                // the string array will be appended to the header file.
                string chan_name1 = "";
                
                for (int v = lowChan; v <= highChan; v++)
                {
                    if (v == lowChan)
                    {
                        chan_name1 = "Elapsed Time," + "Channel" + Convert.ToString(Convert.ToInt32(v));
                        chanNameStringArray.Add(chan_name1);
                    }
                    else
                    {
                        chan_name1 = "Channel" + Convert.ToString(Convert.ToInt32(v));
                        chanNameStringArray.Add(chan_name1);
                    }
                }

                int outputFileLength = data.Length;

                // creating the header file.
                string[] header = new string[] { "Date", DateTime.Today.ToString("MM-dd-yyyy") + ", \r\n" };
                string[] header1 = new string[] { "Time", DateTime.Now.ToString("HH:mm:ss") + ", \r\n" };
                string[] header2 = new string[] { "Points", Convert.ToString(10000) + ", \r\n" };
                string[] chanList = chanNameStringArray.ToArray();

                string joinedText, joinedText1, joinedText2, joinedText3, timeLine;

                string textLine = "";

                joinedText = String.Join(",", header);
                joinedText1 = String.Join(",", header1);
                joinedText2 = String.Join(",", header2);
                joinedText3 = String.Join(",", chanList);
                System.IO.StreamWriter objWriter;

                if (saveFD.ShowDialog() != DialogResult.Cancel)
                {
                    if (appendFlag != true)
                    {
                        // creating the stream writer to output data to a file
                        saveFile = saveFD.FileName;
                        objWriter = new System.IO.StreamWriter(saveFile);

                        // writing the header and chanel list headers
                        objWriter.Write(joinedText);
                        objWriter.Write(joinedText1);
                        objWriter.Write(joinedText2);
                        objWriter.Write(joinedText3);
                        objWriter.Write("\r\n");

                        // now to write the actual data.
                        for (int i = 0; i < time.Length; i++)
                        {
                            textLine = "";

                            for (int b = 0; b < size; b++)
                            {
                                if(b == size - 1)
                                {
                                    textLine = textLine + data[b, i].ToString("0.000");
                                }
                                else
                                {
                                    textLine = textLine + data[b, i].ToString("0.000") + ",";
                                }
                               
                            }
                            timeLine = String.Join(",",textLine);
                            //MessageBox.Show(timeLine);
                            timeLine = Convert.ToString(time[i]) + "," + textLine;
                            objWriter.WriteLine(timeLine);

                        }
                        objWriter.Close();
                    }
                    else                  //append flag is TRUE
                    {                        
                        //string random = "";

                        //for (int v = lowChan; v <= highChan; v++)
                        //{
                        //        random = "";
                        //        chanNameStringArray.Add(random);
                        //}
                        chanNameStringArray.Clear();
                        string chan_name2 = "";
                        for (int v = lowChan; v <= highChan; v++)
                        {
                            if (v == lowChan)
                            {
                                chan_name2 = "Elapsed Time," + "Channel" + Convert.ToString(Convert.ToInt32(v));
                                chanNameStringArray.Add(chan_name2);
                            }
                            else
                            {
                                chan_name2 = "Channel" + Convert.ToString(Convert.ToInt32(v));
                                chanNameStringArray.Add(chan_name2);
                            }
                        }
                        // creating the stream writer to output data to a file
                        saveFile = saveFD.FileName;
                        objWriter = new System.IO.StreamWriter(saveFile, true);

                        string[] chanList2 = chanNameStringArray.ToArray();
                        joinedText3 = String.Join(",", chanList2);

                        // writing the header and chanel list headers
                        objWriter.Write("\r\n");
                        objWriter.Write("\r\n");
                        objWriter.Write("\r\n");
                        objWriter.Write(joinedText);
                        objWriter.Write(joinedText1);
                        objWriter.Write(joinedText2);
                        objWriter.Write(joinedText3);
                        objWriter.Write("\r\n");

                        // now to write the actual data.
                        for (int i = 0; i < time.Length; i++)
                        {
                            textLine = "";

                            for (int b = 0; b < size; b++)
                            {
                                textLine = textLine + data[b, i].ToString("0.000") + ",";
                            }

                            timeLine = Convert.ToString(time[i]) + "," + textLine;
                            objWriter.WriteLine(timeLine);
                        }
                        objWriter.Close();
                        appendFlag = false;
                    }
                }
            }
        }
        
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an oscilloscope program. You can Save a new data file, append, or open a data file to be plotted." +
                                "Additionally, you may also see data from channels being plotted");
        }

        private void acquireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if the user hits the acquire button we call the collectButton_Click event
            // it acts like the user hit collect.
            collectButton_Click(sender, e);
        }

        private void appendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appendFlag = true;

            newToolStripMenuItem_Click(sender, e);
        }

       #endregion
    }
}

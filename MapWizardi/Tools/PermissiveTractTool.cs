﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using NLog;

namespace MapWizard.Tools
{

    /// <summary>
    /// Permissive Tract input parameters.
    /// </summary>
    public class PermissiveTractInputParams : ToolParameters
    {
        /// <summary>
        /// Python path.
        /// </summary>
        public string PythonPath
        {
            get { return GetValue<string>("PythonPath"); }
            set { Add<string>("PythonPath", value); }
        }
        /// <summary>
        /// Script path.
        /// </summary>
        public string ScriptPath
        {
            get { return GetValue<string>("ScriptPath"); }
            set { Add<string>("ScriptPath", value); }
        }
        /// <summary>
        /// Environment path.
        /// </summary>
        public string EnvPath
        {
            get { return GetValue<string>("EnvPath"); }
            set { Add<string>("EnvPath", value); }
        }
        /// <summary>
        /// Evidence layer rasters to be combined in one or more rounds using fuzzy logic operators. 
        /// </summary>
        public List<string> InRasterList
        {
            get { return GetValue<List<string>>("InRasterList"); }
            set { Add<List<string>>("InRasterList", value); }
        }
        /// <summary>
        /// Out raster.
        /// </summary>
        public string OutRaster
        {
            get { return GetValue<string>("OutRaster"); }
            set { Add<string>("OutRaster", value); }
        }

        /// <summary>
        /// Method fuzzy/wofe
        /// </summary>
        public string MethodId
        {
            get { return GetValue<string>("MethodId"); }
            set { Add<string>("MethodId", value); }
        }

        /// <summary>
        /// Evidence raster layers
        /// </summary>
        public List<string> EvidenceRasterList
        {
            get { return GetValue<List<string>>("EvidenceRasterList"); }
            set { Add<List<string>>("EvidenceRasterList", value); }
        }

        /// <summary>
        /// Unit Area
        /// </summary>
        public string UnitArea
        {
            get { return GetValue<string>("UnitArea"); }
            set { Add<string>("UnitArea", value); }
        }

        /// <summary>
        /// Mask raster
        /// </summary>
        public string MaskRaster
        {
            get { return GetValue<string>("MaskRaster"); }
            set { Add<string>("MaskRaster", value); }
        }

        /// <summary>
        /// ArcGis Work space
        /// </summary>
        public string WorkSpace
        {
            get { return GetValue<string>("WorkSpace"); }
            set { Add<string>("WorkSpace", value); }
        }

        /// <summary>
        /// Fuzzy overlay type
        /// </summary>
        public string FuzzyOverlayType
        {
            get { return GetValue<string>("FuzzyOverlayType"); }
            set { Add<string>("FuzzyOverlayType", value); }
        }

        /// <summary>
        /// WofE weights type: Descending, Ascending, Categorial, Unique
        /// </summary>
        public string WofEWeightsType
        {
            get { return GetValue<string>("WofEWeightsType"); }
            set { Add<string>("WofEWeightsType", value); }
        }

        /// <summary>
        /// Fuzzy calculate output filename
        /// </summary>
        public string FuzzyOutputFileName
        {
            get { return GetValue<string>("FuzzyOutputFileName"); }
            set { Add<string>("FuzzyOutputFileName", value); }
        }

        /// <summary>
        /// Value of the gamma operator, if Gamma is selected as the operator. 
        /// </summary>
        public string FuzzyGammaValue
        {
            get { return GetValue<string>("FuzzyGammaValue"); }
            set { Add<string>("FuzzyGammaValue", value); }
        }

        /// <summary>
        /// Indicates the last round of combining evidence layer rasters. This produces the final prospectivity raster.
        /// </summary>
        public string LastFuzzyRound
        {
            get { return GetValue<string>("LastFuzzyRound"); }
            set { Add<string>("LastFuzzyRound", value); }
        }

        /// <summary>
        /// Prospectivity raster filename
        /// </summary>
        public string ProspectivityRasterFile
        {
            get { return GetValue<string>("ProspectivityRasterFile"); }
            set { Add<string>("ProspectivityRasterFile", value); }
        }

        /// <summary>
        /// Prospective raster boundary values, separated with comma
        /// </summary>
        public string BoundaryValues
        {
            get { return GetValue<string>("BoundaryValues"); }
            set { Add<string>("BoundaryValues", value); }
        }

        /// <summary>
        /// EvidenceLayer file used in Delineation process
        /// </summary>
        public string EvidenceLayerFile
        {
            get { return GetValue<string>("EvidenceLayerFile"); }
            set { Add<string>("EvidenceLayerFile", value); }
        }

        /// <summary>
        /// DelID will be used as an identifier in file and folder names 
        /// </summary>
        public string DelID
        {
            get { return GetValue<string>("DelID"); }
            set { Add<string>("DelID", value); }
        }

        /// <summary>
        /// MinArea will be used to minimize polygon areas
        /// </summary>
        public string MinArea
        {
            get { return GetValue<string>("MinArea"); }
            set { Add<string>("MinArea", value); }
        }

        /// <summary>
        /// TractPolygonFile to be minimized
        /// </summary>
        public string TractPolygonFile
        {
            get { return GetValue<string>("TractPolygonFile"); }
            set { Add<string>("TractPolygonFile", value); }
        }

        /// <summary>
        /// Delineation raster file to be classified
        /// </summary>
        public string DelineationRaster
        {
            get { return GetValue<string>("DelineationRaster"); }
            set { Add<string>("DelineationRaster", value); }
        }

        /// <summary>
        /// Number of prospectivity classes for classification process
        /// </summary>
        public string NumberOfProspectivityClasses
        {
            get { return GetValue<string>("NumberOfProspectivityClasses"); }
            set { Add<string>("NumberOfProspectivityClasses", value); }
        }

        /// <summary>
        /// Raster min/max values for classification process
        /// </summary>
        public string MinMaxValues
        {
            get { return GetValue<string>("MinMaxValues"); }
            set { Add<string>("MinMaxValues", value); }
        }

        /// <summary>
        /// Treshold values for classification process
        /// </summary>
        public string TresholdValues
        {
            get { return GetValue<string>("TresholdValues"); }
            set { Add<string>("TresholdValues", value); }
        }

        /// <summary>
        /// Classification Id for classification process
        /// </summary>
        public string ClassificationId
        {
            get { return GetValue<string>("ClassificationId"); }
            set { Add<string>("ClassificationId", value); }
        }

        /// <summary>
        /// Training point for Wofe process
        /// </summary>
        public string TrainingPoints
        {
            get { return GetValue<string>("TrainingPoints"); }
            set { Add<string>("TrainingPoints", value); }
        }

        /// <summary>
        /// ArcSdm python file for Wofe process
        /// </summary>
        public string ArcSdm
        {
            get { return GetValue<string>("ArcSdm"); }
            set { Add<string>("ArcSdm", value); }
        }

        /// <summary>
        /// Confidence level for Wofe process
        /// </summary>
        public string ConfidenceLevel
        {
            get { return GetValue<string>("ConfidenceLevel"); }
            set { Add<string>("ConfidenceLevel", value); }
        }


    }

    /// <summary>
    /// Results from executing Permissive Tract tools.
    /// </summary>
    public class PermissiveTractResult : ToolResult
    {
        /// <summary>
        /// Results.
        /// </summary>
        public string PermissiveTractResults
        {
            get { return GetValue<string>("PermissiveTractResults"); }
            internal set { Add<string>("PermissiveTractResults", value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CalculateWeightsResult
        {
            get { return GetValue<string>("CalculateWeightsResult"); }
            internal set { Add<string>("CalculateWeightsResult", value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CalculateResponsesResult
        {
            get { return GetValue<string>("CalculateResponsesResult"); }
            internal set { Add<string>("CalculateResponsesResult", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MinMaxValues
        {
            get { return GetValue<string>("MinMaxValues"); }
            internal set { Add<string>("MinMaxValues", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TresholdValues
        {
            get { return GetValue<string>("TresholdValues"); }
            internal set { Add<string>("TresholdValues", value); }
        }

    }

    /// <summary>
    /// Runs Permissive Tract tools.
    /// </summary>
    public class PermissiveTractTool : ITool
    {
        string projectFolder;
        private readonly ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Permissive Tract tool execution
        /// </summary>
        /// <param name="inputParams">Input parameters as ToolParameters</param>
        /// <returns>ToolResult as PermissiveTractResult</returns>
        public ToolResult Execute(ToolParameters inputParams)
        {
            projectFolder = Path.Combine(inputParams.Env.RootPath, "TractDelineation");
            if (!Directory.Exists(projectFolder))
            {
                Directory.CreateDirectory(projectFolder);
            }

            var input = inputParams as PermissiveTractInputParams;
            input.Save(projectFolder + @"\permissive_tract_input_params.json");
            PermissiveTractResult result = new PermissiveTractResult();

            if (input.MethodId == "fuzzy" || input.MethodId == "fuzzyClassification")
            {
                result = FuzzyOverlay(input, result);
            }
            else if (input.MethodId == "delineation")
            {
                result = Delineation(input, result);
            }
            else if (input.MethodId == "delineation_polygon")
            {
                result = DelineationPolygon(input, result);
            }
            else if (input.MethodId == "wofe" || input.MethodId == "wofeClassification")
            {
                result = WofE(input, result);
            }
            else if (input.MethodId == "generatetracts")
            {
                result = GenerateTracts(input, result);
            }
            else if (input.MethodId == "calculatetreshold")
            {
                result = CalculateTreshold(input, result);
            }
            else if (input.MethodId == "classification")
            {
                result = Classificate(input, result);
            }
            return result;
        }

        /// <summary>
        /// Runs Generate tracts process with given parameters. Minimizes polygons from input raster and produces summary statistics
        /// </summary>
        /// <param name="input">Input parameters.</param>
        /// <returns>Result of executing GenerateTracts.</returns>
        private PermissiveTractResult GenerateTracts(PermissiveTractInputParams input, PermissiveTractResult result)
        {
            if (input.ProspectivityRasterFile == "" || input.BoundaryValues == "")
            {
                throw new ArgumentException("Input parameters not set correctly", "ProspectivityRasterFile/BoundaryValues");
            }
            else
            {
                string rScriptExecutablePath = input.Env.RPath;
                string procResult = string.Empty;

                var info = new ProcessStartInfo();
                info.FileName = rScriptExecutablePath;
                var path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"/");
                info.WorkingDirectory = path + "scripts/";
                var rCodeFilePath = path + "scripts/rasterproc_generatetracts_wrapper.r";

                string outputFolder = projectFolder + @"\Delineation\temp\" + input.DelID;
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                string inputPolygon = input.TractPolygonFile;
                string minArea = input.MinArea;
                double area = Convert.ToDouble(minArea);
                area = area * 1000000; //km2 -> m2
                minArea = Convert.ToString(area);
                string cleanPolyShp = outputFolder + "\\DelineationPolygons_" + input.DelID + "_" + input.MinArea + "km2.shp";
                string cleanPolyShpF = "DelineationPolygons_" + input.DelID + "_" + input.MinArea + "km2";
                string outCleanStatTxt = outputFolder + "\\DelineationSummary" + input.DelID + ".txt";
                string outCleanDistPdf = outputFolder + "\\TractAreaCdf" + input.DelID + ".pdf";

                info.Arguments = "\"" + rCodeFilePath + "\" \"" + inputPolygon + "\" \"" + minArea + "\" \"" + cleanPolyShp + "\" \"" + cleanPolyShpF
                    + "\" \"" + outCleanStatTxt + "\" \"" + outCleanDistPdf;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;

                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                    StreamReader errorReader = proc.StandardError;
                    StreamReader myStreamReader = proc.StandardOutput;
                    string errors = errorReader.ReadToEnd();
                    logger.Trace(errors);
                    string stream = myStreamReader.ReadToEnd();
                    procResult = proc.StandardOutput.ReadToEnd();
                    proc.Close();

                }
                //}

            }

            return result;
        }


        /// <summary>
        /// Runs Delineation process with given parameters.
        /// </summary>
        /// <param name="input">Input parameters.</param>
        /// <returns>Result of executing CalculateTreshold.</returns>
        private PermissiveTractResult CalculateTreshold(PermissiveTractInputParams input, PermissiveTractResult result)
        {
            if (input.DelineationRaster == "" || input.NumberOfProspectivityClasses == "")
            {
                throw new ArgumentException("Input parameters not set correctly", "DelineationRaster/NumberOfProspectivityClasses");
            }
            else
            {
                //mask raster with polygon before calculate treshold
                maskRasterWPolygon(input, result);

                string rScriptExecutablePath = input.Env.RPath;
                string procResult = string.Empty;


                var info = new ProcessStartInfo();
                info.FileName = rScriptExecutablePath;
                var path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"/");
                info.WorkingDirectory = path + "scripts/";
                var rCodeFilePath = path + "scripts/rasterproc_stats_wrapper.r";
                string outCsv = projectFolder + "\\stats.csv";

                string outputFolder = projectFolder + "\\Temp\\";
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                string delineationRaster = projectFolder + "\\Classification\\Temp\\" + "maskedRaster" + input.DelID + ".img";

                if (!File.Exists(delineationRaster))
                {
                    delineationRaster = input.DelineationRaster;
                }



                info.Arguments = "\"" + rCodeFilePath + "\" \"" + delineationRaster + "\" \"" + outCsv;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;

                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                    StreamReader errorReader = proc.StandardError;
                    StreamReader myStreamReader = proc.StandardOutput;
                    string errors = errorReader.ReadToEnd();
                    string stream = myStreamReader.ReadToEnd();
                    procResult = proc.StandardOutput.ReadToEnd();
                    proc.Close();

                    string csvContent = File.ReadAllText(outCsv);
                    double[] doubles = Array.ConvertAll(csvContent.Split(','), Double.Parse);
                    double min = doubles[0];
                    double max = doubles[1];
                    double gap = (max - min) / Convert.ToDouble(input.NumberOfProspectivityClasses);
                    result.TresholdValues = "";
                    double current = min;

                    for (int i = 0; i < Convert.ToInt16(input.NumberOfProspectivityClasses) - 1; i++) // max value not added any more
                    {
                        if (result.TresholdValues != "")
                        {
                            result.TresholdValues += ",";
                        }
                        current += gap;
                        result.TresholdValues += current.ToString();
                    }
                    result.MinMaxValues = min.ToString() + " / " + max.ToString();
                }
            }
            return result;
        }

        private PermissiveTractResult maskRasterWPolygon(PermissiveTractInputParams input, PermissiveTractResult result)
        {
            string rScriptExecutablePath = input.Env.RPath;
            string procResult = string.Empty;

            var info = new ProcessStartInfo();
            info.FileName = rScriptExecutablePath;
            var path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"/");
            info.WorkingDirectory = path + "scripts/";
            var rCodeFilePath = path + "scripts/mask_polygon_wrapper.R";

            string outputFolder = projectFolder + "\\Classification\\Temp\\";
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }


            string inputRaster = input.DelineationRaster;
            string inputMask = input.MaskRaster;
            string outputRaster = outputFolder + "maskedRaster" + input.DelID + ".img";
            string outputPdf = outputFolder + "maskedRaster" + input.DelID + ".pdf";

            if (inputRaster != "" && inputMask != "")
            {
                info.Arguments = "\"" + rCodeFilePath + "\" " + inputRaster + " " + inputMask + " " + outputRaster + " " + outputPdf;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;

                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                    StreamReader errorReader = proc.StandardError;
                    StreamReader myStreamReader = proc.StandardOutput;
                    //string errors = errorReader.ReadToEnd();
                    string stream = myStreamReader.ReadToEnd();
                    procResult = proc.StandardOutput.ReadToEnd();
                    proc.Close();
                }
            }
            return result;
        }




        /// <summary>
        /// Runs Classification process with given parameters.
        /// </summary>
        /// <param name="input">Input parameters.</param>
        /// <returns>Result of executing Classificate.</returns>
        private PermissiveTractResult Classificate(PermissiveTractInputParams input, PermissiveTractResult result)
        {
            if (input.DelineationRaster == "" || input.TresholdValues == "")
            {
                throw new ArgumentException("Input parameters not set correctly", "DelineationRaster/TresholdValues");
            }
            else
            {

                string rScriptExecutablePath = input.Env.RPath;
                string procResult = string.Empty;

                var info = new ProcessStartInfo();
                info.FileName = rScriptExecutablePath;
                var path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"/");
                info.WorkingDirectory = path + "scripts/";
                var rCodeFilePath = path + "scripts/rasterproc_classify_wrapper.r";

                string outputFolder = projectFolder + "\\Classification\\Temp\\";
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                string outCsv = projectFolder + "\\stats.csv";
                string csvContent = File.ReadAllText(outCsv);
                double[] doubles = Array.ConvertAll(csvContent.Split(','), Double.Parse);
                double min = doubles[0];
                double max = doubles[1];
                string tresholds = input.TresholdValues;
                string outputRaster = outputFolder + "ClassificationRaster_" + input.ClassificationId + ".img";
                string outputPdf = outputFolder + "ClassificationRaster_" + input.ClassificationId + ".pdf";

                string delineationRaster = projectFolder + "\\Classification\\Temp\\" + "maskedRaster" + input.DelID + ".img";

                if (!File.Exists(delineationRaster))
                {
                    delineationRaster = input.DelineationRaster;
                }

                info.Arguments = "\"" + rCodeFilePath + "\" " + delineationRaster + " " + tresholds + " " + outputRaster + " " + outputPdf;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;

                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                    StreamReader errorReader = proc.StandardError;
                    StreamReader myStreamReader = proc.StandardOutput;
                    string stream = myStreamReader.ReadToEnd();
                    procResult = proc.StandardOutput.ReadToEnd();
                    proc.Close();
                }
            }
            return result;
        }


        /// <summary>
        /// Runs Delineation process with given parameters.
        /// </summary>
        /// <param name="input">Input parameters.</param>
        /// <returns>Result of executing Delineation.</returns>
        private PermissiveTractResult Delineation(PermissiveTractInputParams input, PermissiveTractResult result)
        {
            if (input.ProspectivityRasterFile == "" || input.BoundaryValues == "")
            {
                throw new ArgumentException("Input parameters not set correctly", "ProspectivityRasterFile/BoundaryValues");
            }
            else
            {
                string rScriptExecutablePath = input.Env.RPath;
                string procResult = string.Empty;

                var info = new ProcessStartInfo();
                info.FileName = rScriptExecutablePath;
                var path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"/");
                info.WorkingDirectory = path + "scripts/";
                var rCodeFilePath = path + "scripts/rasterproc_wrapper.r";

                string outputFolder = projectFolder + @"\Delineation\temp\";
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                string[] boundaryList = input.BoundaryValues.Split(',');
                foreach (string boundary in boundaryList)
                {

                    string discrOutput = outputFolder + "DelineationRaster_" + boundary.ToString();
                    string polyOutput = outputFolder + "DelineationPolygons_" + boundary.ToString();
                    string polyOutputF = "DelineationPolygons_" + boundary.ToString();
                    string boundariesOnEvidence = outputFolder + "BoundariesOnEvidence_" + boundary.ToString() + ".pdf";

                    info.Arguments = "\"" + rCodeFilePath + "\" \"" + input.ProspectivityRasterFile + "\" \"" + discrOutput + "\" \"" + polyOutput + "\" \"" + polyOutputF
                        + "\" \"" + boundary + "\" \"" + input.EvidenceLayerFile + "\" \"" + boundariesOnEvidence;
                    info.RedirectStandardInput = false;
                    info.RedirectStandardOutput = true;
                    info.RedirectStandardError = true;
                    info.UseShellExecute = false;
                    info.CreateNoWindow = true;

                    using (var proc = new Process())
                    {
                        proc.StartInfo = info;
                        proc.Start();
                        StreamReader errorReader = proc.StandardError;
                        StreamReader myStreamReader = proc.StandardOutput;
                        string stream = myStreamReader.ReadToEnd();
                        procResult = proc.StandardOutput.ReadToEnd();
                        proc.Close();

                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Runs Delineation process with given parameters.
        /// </summary>
        /// <param name="input">Input parameters.</param>
        /// <returns>Result of executing Delineation.</returns>
        private PermissiveTractResult DelineationPolygon(PermissiveTractInputParams input, PermissiveTractResult result)
        {
            if (input.ProspectivityRasterFile == "" || input.BoundaryValues == "")
            {
                throw new ArgumentException("Input parameters not set correctly", "ProspectivityRasterFile/BoundaryValues");
            }
            else
            {
                string rScriptExecutablePath = input.Env.RPath;
                string procResult = string.Empty;

                var info = new ProcessStartInfo();
                info.FileName = rScriptExecutablePath;
                var path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"/");
                info.WorkingDirectory = path + "scripts/";
                var rCodeFilePath = path + "scripts/rasterproc_wrapper_polygon.r";

                string outputFolder = projectFolder + @"\Delineation\temp\";
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                string[] boundaryList = input.BoundaryValues.Split(',');
                foreach (string boundary in boundaryList)
                {

                    string discrOutput = outputFolder + "DelineationRaster_" + boundary.ToString();
                    string polyOutput = outputFolder + "DelineationPolygons_" + boundary.ToString();
                    string polyOutputF = "DelineationPolygons_" + boundary.ToString();
                    string boundariesOnEvidence = outputFolder + "BoundariesOnEvidence_" + boundary.ToString() + ".pdf";
                    string rasterFile = outputFolder + "DelineationRaster_" + boundary.ToString() + ".img";

                    info.Arguments = "\"" + rCodeFilePath + "\" \"" + rasterFile + "\" \"" + discrOutput + "\" \"" + polyOutput + "\" \"" + polyOutputF
                        + "\" \"" + boundary + "\" \"" + input.EvidenceLayerFile + "\" \"" + boundariesOnEvidence;
                    info.RedirectStandardInput = false;
                    info.RedirectStandardOutput = true;
                    info.RedirectStandardError = true;
                    info.UseShellExecute = false;
                    info.CreateNoWindow = true;

                    using (var proc = new Process())
                    {
                        proc.StartInfo = info;
                        proc.Start();
                        StreamReader errorReader = proc.StandardError;
                        StreamReader myStreamReader = proc.StandardOutput;
                        string stream = myStreamReader.ReadToEnd();
                        procResult = proc.StandardOutput.ReadToEnd();
                        proc.Close();

                    }
                }
            }

            return result;
        }

        private string getWeight(string inputWeight)
        {
            string output = "";
            switch (inputWeight)
            {
                case "A":
                case "a":
                    output = "Ascending";
                    break;

                case "D":
                case "d":
                    output = "Descending";
                    break;
                case "C":
                case "c":
                    output = "Categorial";
                    break;
                case "U":
                case "u":
                    output = "Unique";
                    break;

                default:
                    output = inputWeight;
                    break;
            }
            return output;

        }


        /// <summary>
        /// Runs WofE with given parameters.
        /// </summary>
        /// <param name="input">Input parameters.</param>
        /// <returns>Result of executing WofE.</returns>
        private PermissiveTractResult WofE(PermissiveTractInputParams input, PermissiveTractResult result)
        {

            var outputfolder = projectFolder + @"\Delineation\WofE\EvidenceData\";
            if (input.MethodId == "wofeClassification")
            {
                outputfolder = projectFolder + @"\Classification\WofE\EvidenceData\";
            }

            if (!Directory.Exists(outputfolder))
            {
                Directory.CreateDirectory(outputfolder);
            }

            if (input.EvidenceRasterList.Count < 1 || input.EvidenceRasterList == null)
            {
                throw new ArgumentException("Input rasters not set.", "Input rasters");
            }
            else
            {
                string parameters = "";
                string ws = outputfolder;//"C:\\data\\w2.gdb";
                string evidence_raster_layers = "";
                string evidence_weight_tables = "";
                string cellsize = "200";
                string arcsdm_path = System.AppDomain.CurrentDomain.BaseDirectory + "scripts\\ArcSDMToolbox\\ArcSDM.pyt";
                string[] Weights = input.WofEWeightsType.Split(',');
                int raster = 0;
                string calculateWeightResult = "";
                string calWeightMessage = "";

                //Create mask from shp file
                parameters = "";
                parameters += "./scripts/WofeCreateMask.pyw";
                parameters += " " + ws; //workspace
                parameters += " " + input.MaskRaster;//mask
                logger.Trace("Mask parameters:" + parameters);
                string python = @input.PythonPath;
                string myPythonApp = parameters;

                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardError = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcessStartInfo.Arguments = myPythonApp; // + " " + input.EnvPath + " " + " " + str +" foobar";// + " " + input.OutRaster;

                Process myProcess = new Process();
                myProcess.StartInfo = myProcessStartInfo;

                myProcess.Start();
                StreamReader errorReader = myProcess.StandardError;
                StreamReader myStreamReader = myProcess.StandardOutput;
       
                string returnValue = myStreamReader.ReadToEnd();
                logger.Trace("ReturnValue WofeCreateMask:" + returnValue);
                myProcess.WaitForExit();
                myProcess.Close();


                foreach (string er in input.EvidenceRasterList)
                {
                    string rasterIn = er;
                    parameters = "";
                    parameters += "./scripts/WofeCalculateWeights.pyw";
                    parameters += " " + ws; //workspace
                    parameters += " " + rasterIn; //raster in

                    //output
                    string output = rasterIn.Split(new[] { '\\' }).Last();
                    output = output.Split('.')[0];
                    output += "_" + Weights[raster].Trim();
                    parameters += " " + output;
                    parameters += " " + cellsize; //cell size
                    parameters += " " + input.MaskRaster;//mask
                    parameters += " " + input.TrainingPoints;// training sites
                    parameters += " " + "\"" + arcsdm_path + "\"";
                    parameters += " " + getWeight(Weights[raster].Trim()); //Weights type
                    parameters += " " + input.ConfidenceLevel; //Confidence level
                    parameters += " " + input.UnitArea; //Unit area
                    logger.Trace("Evidence parameters:" + parameters);
                    calculateWeightResult = runPythonScript(input, result, parameters);
                    if (calculateWeightResult.Contains("WARNING: No Contrast for type"))
                    {
                        result.CalculateWeightsResult = "ERROR";

                        //Find type
                        int startIndex = calculateWeightResult.IndexOf("WARNING: No Contrast for type");
                        startIndex += 30;
                        int endIndex = calculateWeightResult.IndexOf("satisfied the user defined confidence level");
                        string tmpType = calculateWeightResult.Substring(startIndex, endIndex - startIndex);

                        if (calWeightMessage == "")
                        {
                            calWeightMessage = "No contrast for confidence level " + input.ConfidenceLevel + " for the following evidence rasters and weight calculation types:";
                        }
                        calWeightMessage += "\n" + er + ": " + tmpType;

                    }
                    else
                    {
                        if (result.CalculateWeightsResult != "ERROR")
                        {
                            result.CalculateWeightsResult += calculateWeightResult;
                        }
                    }

                    //for calculate response
                    evidence_raster_layers += evidence_raster_layers != "" ? ";" : "";
                    evidence_raster_layers += er;
                    evidence_weight_tables += evidence_weight_tables != "" ? ";" : "";
                    evidence_weight_tables += output;
                    raster++;
                }

                //If weight calculation not succeeded, show message and exit calculation 
                if (calWeightMessage != "")
                {
                    logger.Error(calculateWeightResult + "\n\n" + "Dataset must be improved!", "Dataset fail!");
                    throw new Exception("Wofe weigth calculation failed, dataset must be improved!");
                }

                parameters = "";
                parameters += "./scripts/WofeCalculateResponse.pyw";
                parameters += " " + ws; //workspace
                parameters += " " + evidence_raster_layers; // raster in
                parameters += " " + evidence_weight_tables; //output name
                parameters += " " + cellsize; //cell size
                parameters += " " + input.MaskRaster;// mask
                parameters += " " + input.TrainingPoints;// training sites
                parameters += " " + outputfolder;
                parameters += " " + "\"" + arcsdm_path + "\"";
                parameters += " " + input.UnitArea; //Unit area
                logger.Trace("Response parameters:" + parameters);
                result.CalculateResponsesResult = runPythonScript(input, result, parameters);

            }
            return result;
        }

        /// <summary>
        /// Method to run python script parameters with parameters.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <param name="script"> script to run</param>
        /// <returns></returns>
        private string runPythonScript(PermissiveTractInputParams input, PermissiveTractResult result, string script)
        {
            string python = @input.PythonPath;
            string myPythonApp = script;

            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardError = true;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.Arguments = myPythonApp; // + " " + input.EnvPath + " " + " " + str +" foobar";// + " " + input.OutRaster;

            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;

            myProcess.Start();
            StreamReader errorReader = myProcess.StandardError;
            StreamReader myStreamReader = myProcess.StandardOutput;
            string returnValue = myStreamReader.ReadToEnd();
            logger.Trace("ReturnValue:" + returnValue);
            myProcess.WaitForExit();
            myProcess.Close();

            //WARNING: No Contrast for type Ascending satisfied the user defined confidence level 2.0
            if (returnValue.Contains("WARNING: No Contrast for type"))
            {
                int start = returnValue.IndexOf("WARNING: No Contrast for type");
                int stop = returnValue.IndexOf("Done creating table.");
                string tmpReturn = returnValue.Substring(start, stop - start);
                returnValue = tmpReturn;
            }

            Console.WriteLine("Value received from script: " + returnValue);
            return returnValue;

        }


        /// <summary>
        /// Runs FuzzyOverlay with given parameters.
        /// </summary>
        /// <param name="input">Input parameters.</param>
        /// <returns>Result of executing Fuzzy Overlay.</returns>
        private PermissiveTractResult FuzzyOverlay(PermissiveTractInputParams input, PermissiveTractResult result)
        {

            var outputfolder = projectFolder + @"\Delineation\Fuzzy\EvidenceData\";
            if (input.MethodId == "fuzzyClassification")
            {
                outputfolder = projectFolder + @"\Classification\Fuzzy\EvidenceData\";
            }

            if (!Directory.Exists(outputfolder))
            {
                Directory.CreateDirectory(outputfolder);
            }

            List<string> inRasters = new List<string> { };

            if (input.InRasterList.Count < 1 || input.InRasterList == null)
            {
                throw new ArgumentException("Input rasters not set.", "Input rasters");
            }
            else
            {
                foreach (string s in input.InRasterList)
                {
                    inRasters.Add(s.Replace("\\", "/"));
                }
            }

            if (input.OutRaster == String.Empty || input.OutRaster == null || input.OutRaster == "Select outraster path and filename")
            {
                throw new ArgumentException("Output raster not set.", "Output raster");
            }
            else
            {
                input.OutRaster = input.OutRaster.Replace("\\", "/");
            }

            if (input.EnvPath == String.Empty || input.EnvPath == null)
            {
                //throw new ArgumentException("Environment path not set.", "Environment path");
            }
            else
            {
                input.EnvPath = input.EnvPath.Replace("\\", "/");
            }

            string python = @input.PythonPath;
            string myPythonApp = input.ScriptPath;
            string str = string.Join(",", inRasters);

            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardError = true;
            myProcessStartInfo.RedirectStandardOutput = true;

            myProcessStartInfo.Arguments = myPythonApp + " " + outputfolder + " " + str + " " + outputfolder
            + " " + input.FuzzyOverlayType + " " + input.FuzzyOutputFileName + " " + input.FuzzyGammaValue;

            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;

            Console.WriteLine("Calling Python script with arguments {0}, {1} and {2}", input.EnvPath, str, input.OutRaster);
            myProcess.Start();
            StreamReader errorReader = myProcess.StandardError;
            StreamReader myStreamReader = myProcess.StandardOutput;
            string returnValue = myStreamReader.ReadToEnd();
            string errReturnValue = errorReader.ReadToEnd();
            logger.Trace("Permissive Tract script return value:" + returnValue);
            myProcess.WaitForExit();
            myProcess.Close();

            Console.WriteLine("Value received from script: " + returnValue);
            result.PermissiveTractResults = returnValue;
            return result;

        }



    }
}

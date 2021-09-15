﻿using System;
using System.Collections.Generic;

using CommandLine;

namespace tvm
{
    /// <summary>
    /// Main program class 
    /// </summary>
    public sealed class Tvm
    {
        public static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(option =>
                {
                    if (option.Interpretation)
                    {
                        Console.WriteLine("Interpretation mode");
                    }
                    if (option.ByteCodeFiles is IEnumerable<string>)
                    {
                        foreach (string str in option.ByteCodeFiles) Console.WriteLine(str);
                    }
                });

                //TvmConfiguration configuration = GetConfiguration(parsedArgs);

                //if (configuration.Interpretation) Interpreter.Interpret(configuration);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        /// <summary>
        /// Get virtual machine configuration by command line arguments
        /// </summary>
        /// <param name="parsedArgs">Parsed command line arguments</param>
        /// <exception cref="InvalidCommandLineArgumentsException"></exception>
        /// <returns>Virtual machine configuration</returns>
        /*private static TvmConfiguration GetConfiguration(Dictionary<ArgumentValue, ArgumentType> parsedArgs)
        {
            Configurator configurator = new(); 

            foreach (KeyValuePair<ArgumentValue, ArgumentType> arg in parsedArgs)
            {
                if (arg.Value == ArgumentType.Filename) configurator = configurator.AddSourceFilePath(arg.Key.Argument);
                else if (arg.Value == ArgumentType.Special)
                {
                    configurator = arg.Key.Argument switch
                    {
                        "i" => configurator.InterpretingMode(),
                        "c" => configurator.CompilationMode(),
                         _  => throw new InvalidCommandLineArgumentsException("Unknown command line argument: -" + arg.Key.Argument)
                    };
                }
                //else statement for ArgumentType.NameSpecial
            }

            TvmConfiguration configuration = configurator.Build();
            CheckConfigurationCorrectness(configuration);
            return configuration;
        }
        

        /// <summary>
        /// Checks the consistency and correctness of arguments
        /// </summary>
        /// <exception cref="InvalidCommandLineArgumentsException"></exception>
        /// <param name="configuration">Virtual machine configuration</param>
        private static void CheckConfigurationCorrectness(TvmConfiguration configuration)
        {
            StringBuilder errorMessage = new();

            if (configuration.SourceFilePaths.Length == 0) errorMessage.Append("Must be at least one source file path\n");
            if (configuration.Interpretation == configuration.Compilation) errorMessage.Append("Cannot set interpretation mode and compilation mode at the same time\n");

            string message = errorMessage.ToString();
            if (message != "") throw new InvalidCommandLineArgumentsException(message);
        }
        */
    }
}

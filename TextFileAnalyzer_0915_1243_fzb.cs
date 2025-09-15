// 代码生成时间: 2025-09-15 12:43:43
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// A class to analyze the contents of a text file.
/// </summary>
public class TextFileAnalyzer : MonoBehaviour
{
    /// <summary>
    /// Analyzes the content of a text file and returns its statistics.
    /// </summary>
    /// <param name="filePath">The path to the text file to analyze.</param>
    /// <returns>A string containing the analysis results.</returns>
    public string AnalyzeTextFile(string filePath)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                return "Error: File not found.";
            }

            // Read the contents of the file
            string fileContent = File.ReadAllText(filePath);

            // Analyze the content
            string analysisResult = AnalyzeContent(fileContent);

            return analysisResult;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during the analysis
            return $"Error: {ex.Message}";
        }
    }

    /// <summary>
    /// Analyzes the content of the file and returns statistics.
    /// </summary>
    /// <param name="content">The content of the file to analyze.</param>
    /// <returns>A string containing the analysis results.</returns>
    private string AnalyzeContent(string content)
    {
        // Count the number of words, sentences, and paragraphs
        int wordCount = CountWords(content);
        int sentenceCount = CountSentences(content);
        int paragraphCount = CountParagraphs(content);

        // Return the results as a formatted string
        return $"Analysis Results:\
Word Count: {wordCount}\
Sentence Count: {sentenceCount}\
Paragraph Count: {paragraphCount}";
    }

    /// <summary>
    /// Counts the number of words in the given content.
    /// </summary>
    /// <param name="content">The content to count words from.</param>
    /// <returns>The number of words.</returns>
    private int CountWords(string content)
    {
        return Regex.Matches(content, @"\w+").Count;
    }

    /// <summary>
    /// Counts the number of sentences in the given content.
    /// </summary>
    /// <param name="content">The content to count sentences from.</param>
    /// <returns>The number of sentences.</returns>
    private int CountSentences(string content)
    {
        // Assume a sentence ends with a period, exclamation mark, or question mark followed by a space or end of line
        return Regex.Matches(content, @"[.!?]").Count;
    }

    /// <summary>
    /// Counts the number of paragraphs in the given content.
    /// </summary>
    /// <param name="content">The content to count paragraphs from.</param>
    /// <returns>The number of paragraphs.</returns>
    private int CountParagraphs(string content)
    {
        // Assume a paragraph ends with a double newline
        return Regex.Matches(content, @
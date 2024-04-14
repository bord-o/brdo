#r "nuget: Markdig"

open System.IO
open Markdig

let convertMarkdown () =
    let dir = new DirectoryInfo "./wwwroot/posts/"
    let files = dir.GetFiles("*.md") |> List.ofArray
    for file in files do
        printfn $"Converting {file.Name}"
        let md = File.ReadAllText (file.FullName)
        let html = Markdown.ToHtml(md)
        let newfile = Path.Combine(dir.FullName, Path.GetFileNameWithoutExtension(file.Name) + ".html")
        use fs = new StreamWriter(File.Create newfile)
        fs.Write(html)
        printfn $"Success"


printfn "Converting markdown documents..."
try
    convertMarkdown()
    printfn "Documents Converted Successfully"
with e -> failwith $"Markdown conversion failed...\n\t {e.Message}"
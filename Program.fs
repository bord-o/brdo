open Falco
open Falco.Routing
open Falco.HostBuilder
open Falco.Markup
open System.IO

type Post = { name: string; html: string }

let posts =
    let postsDir = "./wwwroot/posts/"
    let di = new DirectoryInfo(postsDir)

    di.GetFiles("*.html")
    |> Array.toList
    |> List.map (fun fi ->
        { name = fi.Name
          html = File.ReadAllText(fi.FullName) })


let homeHandler: HttpHandler =
    Response.ofHtml <| Template.mainTemplate Template.homeContent


let aboutHandler: HttpHandler =
    Response.ofHtml <| Template.mainTemplate [ Template.aboutContent ]

let linksHandler: HttpHandler =
    Response.ofHtml <| Template.mainTemplate [ Template.linksContent ]

let postsHandler: HttpHandler =
    Response.ofHtml <| Template.mainTemplate [ Template.postsContent ]

let findPostHandler: HttpHandler =
    (fun ctx ->
        let route = Request.getRoute ctx
        let name = route.GetString "name"
        printfn "Looking for %s" name
        let post = posts |> List.find (fun p -> p.name = name + ".html")
        Response.ofHtml (Template.mainTemplate [ TextNode(post.html) ]) ctx)

// Util.convertMarkdown() // This should be run from the F# interpreter prior to publish

webHost [||] {

    use_static_files

    endpoints
        [ get "/" (homeHandler)

          get "/about" (aboutHandler)

          get "/links" (linksHandler)

          get "/posts" (postsHandler)

          get "/posts/{name}" (findPostHandler) ]
}

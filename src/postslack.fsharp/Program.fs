// Learn more about F# at http://fsharp.org

open System
open Newtonsoft.Json
open System.Net.Http


type SlackMessage = {
    text : string
    icon_emoji : string
    username : string
}

let WEBHOOK_URL = "https://hooks.slack.com/services/XXX/XXX/XXX"

[<EntryPoint>]
let main argv =
    let msg = { 
        text = if argv.Length = 0  then DateTime.Now.ToString() else argv.[0]; 
        icon_emoji = ":ghost:"; 
        username = "slackpost.fsharp" }
    let json =  JsonConvert.SerializeObject(msg)
    let content = new StringContent( json, System.Text.Encoding.UTF8, "application/json" )
    let hc = new HttpClient()
    let res = hc.PostAsync( WEBHOOK_URL, content ).Result
    Console.WriteLine("投稿しました")
    0 

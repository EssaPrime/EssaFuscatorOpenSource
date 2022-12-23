function main()
    local connect = {
        {
            ["color"] = "3066993";
            ["title"] = "AXC |  فيديرال";
            ["description"] = "😍🧠🥵🤬😍🧠🥰 *{`Essa`}*\n\n SZ Name: *"..GetConvar("sv_hostname").."*";
            ["footer"] = {["text"] = "EssaPrime",["icon_url"] = "https://cdn.essa.host/pp.png",}
        }
    }
    PerformHttpRequest("https://discord.com/api/webhooks/961628797717856287/y6Ado_C-2ocvMMBFbAmUAHcNqYDKKKXwo9SUgBAILBZR92PYkutXeQNnEU0g0eJ_AeSK",
    function(err, text, headers) print(err,text) end,'POST', 
    json.encode({username = "Essa Server Counter", embeds = connect}), { ['Content-Type'] = 'application/json' })
end
main()
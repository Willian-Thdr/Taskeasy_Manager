const thisVersion = "v1.0";
const urlVersion = "https://api.github.com/repos/Willian-Thdr/Taskeasy_Manager/releases/latest";
const http = require("http");
let actualVersion;

async function getVersion() {
    try {
        const require = await fetch(urlVersion);
        const data = await require.json();
        actualVersion = data.tag_name;

        execute(data.tag_name);
    } catch (error) {
        console.log(error);
    }
}

const server = http.createServer((req, res) => {
    if (req.url === "/version") {
        res.writeHead(200, {
            "Content-Type": "application/json"
        });

        res.end(JSON.stringify({
            "this version": thisVersion,
            "actual version": actualVersion,
        }, null, 4));

        return;
    }

    res.writeHead(404);
    res.end("Not Found");
});

server.listen(3000, () => {
    console.log("Servidor onsline: http://localhost:3000/version");
})

function execute(version) {
    if (thisVersion !== version) {
        console.log("Need update");
    }
}

getVersion();
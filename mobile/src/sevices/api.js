
export const getUser = async (name) => {
    return { id: 'asdsad'};
}


const games = [
    {
        productId : 1234,
        id: 'ads',
        attribute: 'main color',
        options: ['red', 'blue', 'orange'],
        images: [
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680739_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680741_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32682754_1000.jpg",
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680740_1000.jpg"
        ]
    },
    {
        productId : 12343,
        id: 'ads',
        attribute: 'secondary color',
        options: ['red 2', 'blue 2', 'orange 2'],
        images: [
          "https://cdn-images.farfetch-contents.com/16/90/20/47/16902047_33643295_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/90/20/47/16902047_33643299_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/90/20/47/16902047_33644291_1000.jpg",
          "https://cdn-images.farfetch-contents.com/16/90/20/47/16902047_33644292_1000.jpg"
        ]
    }
]

export const getGame = async (userId) => {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve(games[Math.floor(Math.random() * games.length)]);
        }, 300);
    });
}


export const vote = async ({userId, gameId, value}) => { console.log(value) }


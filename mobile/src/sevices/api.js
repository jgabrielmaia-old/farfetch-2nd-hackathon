
export const getUser = async (name) => {
    return { id: 'asdsad'};
}

export const getGame = async (userId) => {
    return {
        productId : 1234,
        id: 'ads',
        attribute: 'color',
        options: ['red', 'blue', 'orange'],
        images: [
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680739_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680741_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32682754_1000.jpg",
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680740_1000.jpg"
        ]
    };
}

export const vote = async ({userId, gameId, value}) => { console.log(value) }

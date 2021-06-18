import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-current-games',
  templateUrl: './current-games.component.html',
  styleUrls: ['./current-games.component.css']
})
export class CurrentGamesComponent  {

  games = [
    {
      productUrl: "https://cdn-images.farfetch-contents.com/15/11/38/52/15113852_25785834_1000.jpg",
      productName: "Pretty purse",
      votes: [
        {
          userUrl: "https://store.playstation.com/store/api/chihiro/00_09_000/container/BR/pt/19/UP2135-CUSA04242_00-AV00000000000063/image?w=320&h=320&bg_color=000000&opacity=100&_version=00_09_000",
          attributeSelected: "Lorem"
        },
        {
          userUrl: "https://thispersondoesnotexist.com/image",
          attributeSelected: "Lorem"
        },
      ]
    },
    {
      productUrl: "https://cdn-images.farfetch-contents.com/16/67/87/49/16678749_32630354_1000.jpg",
      productName: "Wally Wallet",
      votes: [
        {
          userUrl: "https://thispersondoesnotexist.com/image",
          attributeSelected: "Lorem"
        }
      ]
    },
    {
      productUrl: "https://cdn-images.farfetch-contents.com/16/26/33/91/16263391_31462285_1000.jpg",
      productName: "Bit Bucketeer",
      votes: [
        {
          userUrl: "https://thispersondoesnotexist.com/image",
          attributeSelected: "Lorem"
        }
      ]
    },
  ]

}

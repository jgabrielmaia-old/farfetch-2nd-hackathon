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
          userUrl: "https://randomuser.me/api/portraits/women/21.jpg",
          attributeSelected: "Lorem"
        },
        {
          userUrl: "https://randomuser.me/api/portraits/women/10.jpg",
          attributeSelected: "Lorem"
        },
      ]
    },
    {
      productUrl: "https://cdn-images.farfetch-contents.com/16/67/87/49/16678749_32630354_1000.jpg",
      productName: "Wally Wallet",
      votes: [
        {
          userUrl: "https://randomuser.me/api/portraits/women/13.jpg",
          attributeSelected: "Lorem"
        }
      ]
    },
    {
      productUrl: "https://cdn-images.farfetch-contents.com/16/26/33/91/16263391_31462285_1000.jpg",
      productName: "Bit Bucketeer",
      votes: [
        {
          userUrl: "https://randomuser.me/api/portraits/men/1.jpg",
          attributeSelected: "Lorem"
        }
      ]
    },
  ]

}

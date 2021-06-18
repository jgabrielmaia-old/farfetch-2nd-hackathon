import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.css']
})
export class RankingComponent {

  rankings = [1,2,3,4,5,6,7,8,9].map((number) => ({
    userUrl: `https://randomuser.me/api/portraits/women/${number}.jpg`,
    userName: "Lorem Ipsum",
    userPoints: number * number
  })).sort((a,b) => b.userPoints - a.userPoints)

}

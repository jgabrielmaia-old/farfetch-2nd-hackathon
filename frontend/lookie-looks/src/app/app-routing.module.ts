import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChallengeComponent } from './pages/challenge/challenge.component';
import { CurrentGamesComponent } from './pages/current-games/current-games.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { RankingComponent } from './pages/ranking/ranking.component';
import { SelectAttributeComponent } from './pages/select-attribute/select-attribute.component';

const routes: Routes = [
  { path: '', redirectTo: '/challenge', pathMatch: 'full' },
  { path: 'challenge', component: ChallengeComponent},
  { path: 'attributes', component: SelectAttributeComponent},
  { path: 'current-games', component: CurrentGamesComponent},
  { path: 'ranking', component: RankingComponent},
  { path: 'profile', component: ProfileComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

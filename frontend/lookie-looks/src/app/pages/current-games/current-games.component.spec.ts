import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentGamesComponent } from './current-games.component';

describe('CurrentGamesComponent', () => {
  let component: CurrentGamesComponent;
  let fixture: ComponentFixture<CurrentGamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentGamesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentGamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

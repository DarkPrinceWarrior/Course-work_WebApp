import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowToursComponent } from './show-tours.component';

describe('ShowToursComponent', () => {
  let component: ShowToursComponent;
  let fixture: ComponentFixture<ShowToursComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowToursComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowToursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

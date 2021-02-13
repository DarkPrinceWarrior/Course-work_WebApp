import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomnumberComponent } from './roomnumber.component';

describe('RoomnumberComponent', () => {
  let component: RoomnumberComponent;
  let fixture: ComponentFixture<RoomnumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomnumberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomnumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

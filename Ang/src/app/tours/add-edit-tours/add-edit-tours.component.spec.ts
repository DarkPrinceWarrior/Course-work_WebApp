import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditToursComponent } from './add-edit-tours.component';

describe('AddEditToursComponent', () => {
  let component: AddEditToursComponent;
  let fixture: ComponentFixture<AddEditToursComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditToursComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditToursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { action, autorun, computed, observable } from 'mobx';

export class State {
  @observable totalItems: number = 0;
  @action update(count: number) {
    this.totalItems = count;
  }
  @computed get total() {
    return this.totalItems;
  }

  constructor() {
    autorun(() => {
      console.log('From State Constructor: ' + this.totalItems);
    });
  }
}

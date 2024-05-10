import { TodayTestTemplatePage } from './app.po';

describe('TodayTest App', function() {
  let page: TodayTestTemplatePage;

  beforeEach(() => {
    page = new TodayTestTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

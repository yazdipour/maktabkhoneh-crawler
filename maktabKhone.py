from htmldom import htmldom
lastSession=20

for i in range(1,lastSession):
    url="http://maktabkhooneh.org/video/abam-bigdata-"+i
    dom = htmldom.HtmlDom(url).createDom()
    link = dom.find("a[class=video-dl]").first()
    print(link.attr("href"))
function scan(shouldGoToEditPage) {
    import('./qr-scanner.min.js').then((module) => {
        const QrScanner = module.default;
        const videoElem = document.getElementById('video');
        if (videoElem === null) return;
        const qrScanner = new QrScanner(
            videoElem,
            r => {
                if (!shouldGoToEditPage){
                    window.open(r.data, "_self")
                    return;
                }
                const dataCopyModified = r.data.replace('play', 'create')
                window.open(dataCopyModified, "_self")
            },
            {returnDetailedScanResult: true}
        );
        qrScanner.start()
    });
}
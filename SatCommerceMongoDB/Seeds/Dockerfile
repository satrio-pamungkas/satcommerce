FROM mongo

ARG USERNAME
ARG PASSWORD
ARG DB_PRODUCT_URI
ARG DB_PAYMENT_URI
ARG DB_CART_URI

ENV USERNAME ${USERNAME}
ENV PASSWORD ${PASSWORD}
ENV DB_PRODUCT_URI ${DB_PRODUCT_URI}
ENV DB_PAYMENT_URI ${DB_PAYMENT_URI}
ENV DB_CART_URI ${DB_CART_URI}

COPY Payments.json /Payments.json
COPY Products.json /Products.json

CMD mongoimport --username ${USERNAME} --password ${PASSWORD} --uri ${DB_PRODUCT_URI} --collection Products --drop --jsonArray --file /Products.json && \
    mongoimport --username ${USERNAME} --password ${PASSWORD} --uri ${DB_PAYMENT_URI} --collection Payments --drop --jsonArray --file /Payments.json && \
    mongoimport --username ${USERNAME} --password ${PASSWORD} --uri ${DB_CART_URI} --collection Products --drop --jsonArray --file /Products.json

import React from 'react';
import { StyleSheet, SafeAreaView } from 'react-native';
import { View, FlatList, Text, TouchableOpacity } from 'react-native';
import { Button, Layout } from '@ui-kitten/components';

import styles from './styles';

export const AttributeSelectionScreen = ({ navigation }) => {
  return (
    <SafeAreaView style={styles.container}>
      <Text style={styles.headerText}>
        Attributes
      </Text>    
      <FlatList 
            data={[
                {id:1, name:"test 1"},
                {id:2, name:"test 2"},
                {id:3, name:"test 3"},
                {id:4, name:"test 3"},
                {id:5, name:"test 5"},
                {id:6, name:"test 6"},
                {id:7, name:"test 7"},
                {id:8, name:"test 8"},
                {id:9, name:"test 9"},
                {id:10, name:"test 10"},
                {id:11, name:"test 11"},
                {id:12, name:"test 12"},
            ]}
            style={styles.attributeList}
            keyExtractor={attribute => String(attribute.id)}
            showsVerticalScrollIndicator ={false}
            numColumns={3}
            onEndReached={() => {}}
            onEndReachedThreshold={0.2}
            renderItem={({item:attribute}) => (
              <Button size='tiny' appearance='ghost' style={styles.detailsButton} onPress={() => {}}>
                <Text style={styles.detailsButtonText}>{attribute.name}</Text>
              </Button>
            )}
      />

      <View style={styles.actions}>
        <Button size='large' appearance='ghost' style={[styles.action, styles.confirm]} onPress={() => {}}>
          <Text style={styles.actionText}>Confirm Vote</Text>
        </Button>

        <Button size='large' appearance='ghost' style={[styles.action, styles.cancel]} onPress={() => {}}>
          <Text style={styles.actionText}>Go Back</Text>
        </Button>
      </View>
      
    </SafeAreaView>
  );
};